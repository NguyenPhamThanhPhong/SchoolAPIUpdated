using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs;
using SchoolApi.Infrastructure.Entities.UserGroups;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.ServiceDTOS.PostServiceDTOs;
using AutoMapper;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.ServiceDTOS.Base;
using SchoolApi.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Infrastructure.Services.AzureBlobServices;
using SchoolApi.Infrastructure.Services.HelperServices;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface IPostService
    {
        Task<Post?> CreateSinglePost(PostCreateServiceRequest request);
        Task<MultipleEntitiesResponse<Post>> CreateMultiplePosts(IEnumerable<PostCreateServiceRequest> requests);
        Task<Post?> GetPostDetail(string semesterId);
        Task<MultipleEntitiesResponse<Post>> GetMultiplePosts(BaseGetMultipleServiceRequest request);
        Task<bool> DeleteSinglePost(string postId);
        Task<bool> DeleteMultiplePosts(IEnumerable<string> postIds);
        Task<MultipleEntitiesResponse<Post>> SearchPost(BaseSearchServiceRequest request);
        Task<Post?> UpdatePost(PostUpdateServiceRequest serviceRequest);
    }
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitofWork;
        private readonly AzureBlobHandler _azureBlobHandler;
        private readonly ServiceHelper _serviceHelper;

        public PostService(IMapper mapper, UnitOfWork unitofWork, AzureBlobHandler azureBlobHandler, ServiceHelper serviceHelper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
            _azureBlobHandler = azureBlobHandler;
            _serviceHelper = serviceHelper;
        }

        public Task<MultipleEntitiesResponse<Post>> CreateMultiplePosts(IEnumerable<PostCreateServiceRequest> requests)
        {
            try
            {
                var posts = _mapper.Map<IEnumerable<Post>>(requests);
                _unitofWork.postRepository.AddRange(posts);
                _unitofWork.Save();
                return Task.FromResult(new MultipleEntitiesResponse<Post>(true) { datas = posts });
            }catch { return Task.FromResult(new MultipleEntitiesResponse<Post>(false)); }
        }

        public Task<Post?> CreateSinglePost(PostCreateServiceRequest request)
        {
            try
            {
                var post = _mapper.Map<Post>(request);
                _unitofWork.postRepository.Add(post);
                _unitofWork.Save();
                return Task.FromResult<Post?>(post);
            }catch { return Task.FromResult<Post?>(null); }
        }

        public Task<bool> DeleteMultiplePosts(IEnumerable<string> postIds)
        {
            try
            {
                var posts = _unitofWork.postRepository.GetRange(s => postIds.Contains(s.id));
                _unitofWork.postRepository.RemoveRange(posts);
                _unitofWork.Save();
                return Task.FromResult(true);
            }catch { return Task.FromResult(false); }
        }

        public Task<bool> DeleteSinglePost(string postId)
        {
            try
            {
                var post = _unitofWork.postRepository.GetSingle(s => s.id == postId);
                if (post == null)
                    return Task.FromResult(false);
                _unitofWork.postRepository.Remove(post);
                _unitofWork.Save();
                return Task.FromResult(true);
            }
            catch { return Task.FromResult(false); }
        }

        public Task<MultipleEntitiesResponse<Post>> GetMultiplePosts(BaseGetMultipleServiceRequest request)
        {
            try
            {
                var posts = _unitofWork.postRepository.GetRange(s=>true)
                    .Skip(request.page * request.pageSize).Take(request.pageSize);
                var count = _unitofWork.postRepository.GetCountDefault();
                return Task.FromResult(new MultipleEntitiesResponse<Post>(true)
                {
                    datas = posts,
                    TotalCount = count
                });
            }
            catch { return Task.FromResult(new MultipleEntitiesResponse<Post>(false));}
        }

        public Task<Post?> GetPostDetail(string semesterId)
        {
            var post = _unitofWork.postRepository.GetDetailFromId(semesterId);
            return Task.FromResult(post);
        }

        public Task<MultipleEntitiesResponse<Post>> SearchPost(BaseSearchServiceRequest request)
        {
            var cleanSearchTerm = StringHelper.cleanSearchTerm(request.searchTerm);
            var posts = _unitofWork.postRepository.GetRange(s => 
                EF.Functions.Like(s.title.ToLower(), $"%{cleanSearchTerm}%"));
            var count = posts.Count();
            posts = posts.Skip(request.page * request.pageSize).Take(request.pageSize);
            return Task.FromResult(new MultipleEntitiesResponse<Post>(true)
            {
                datas = posts,
                TotalCount = count
            });
        }

        public Task<Post?> UpdatePost(PostUpdateServiceRequest serviceRequest)
        {
            var post = _unitofWork.context.Set<Post>()
                .Include(post => post.faculties).FirstOrDefault(s => s.id == serviceRequest.id);
            var faculties = _unitofWork.facultyRepository.GetRange(
                s => serviceRequest.faculyIds.Contains(s.id)).ToList();
            if(post == null)
                return Task.FromResult<Post?>(null);

            _mapper.Map(serviceRequest, post);
            var currentFileDict = post.fileUrlsDict;
            post.faculties = faculties;
            post.fileUrlsDict = _serviceHelper.GenerateFileDictFromRequest(currentFileDict, serviceRequest.keepUrls, serviceRequest.files);
            _unitofWork.Save();
            return Task.FromResult<Post?>(post);
        }
    }
}
