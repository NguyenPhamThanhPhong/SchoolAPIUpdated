using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs;
using SchoolApi.Infrastructure.Entities.UserGroups;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.ServiceDTOS.PostServiceDTOs;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface IPostService
    {
        public Task<Post> CreateSinglePost(PostCreateServiceRequest request);
        public Task<IEnumerable<Post>> CreateMultiplePosts(IEnumerable<PostCreateServiceRequest> requests);
        public Task<Post> GetPostDetail(string semesterId);
        public Task<MultipleEntitiesResponse<Post>> GetMultiplePosts(int page);
        public Task<bool> DeletePost(string semesterId);
        public Task<MultipleEntitiesResponse<Post>> SearchPost(string searchTerm);
        Task<Post> UpdatePost(PostUpdateServiceRequest serviceRequest);
        Task<bool> DeleteSinglePost(string postId);
    }
    public class PostService : IPostService
    {
        public Task<IEnumerable<Post>> CreateMultiplePosts(IEnumerable<PostCreateServiceRequest> requests)
        {
            throw new NotImplementedException();
        }

        public Task<Post> CreateSinglePost(PostCreateServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost(string semesterId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSinglePost(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Post>> GetMultiplePosts(int page)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostDetail(string semesterId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Post>> SearchPost(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePost(PostUpdateServiceRequest serviceRequest)
        {
            throw new NotImplementedException();
        }
    }
}
