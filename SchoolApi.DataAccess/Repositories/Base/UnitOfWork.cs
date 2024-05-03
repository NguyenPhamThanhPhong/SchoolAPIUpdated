using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.InformationTypeGroups;
using SchoolApi.Infrastructure.Repositories.UserGroups;


namespace SchoolApi.Infrastructure.Repositories.Base
{

    public class UnitOfWork : IDisposable
    {
        public SchoolDbContext context;
#pragma warning disable CS8618
        public UnitOfWork(SchoolDbContext context)
        {
            this.context = context;
        }
#pragma warning restore CS8618

        private IFacultyRepository  _facultyRepository  ;
        private IPostRepository     _postRepository     ;
        private ISemesterRepository _semesterRepository ;
        private ISubjectRepository  _subjectRepository  ;
        private IUserRepository     _userRepository     ;
        private IStudentRepository  _studentRepository  ;
        private ILecturerRepository _lecturerRepository ;
        private ISchoolClassRepository _schoolClassRepository;


        public IFacultyRepository facultyRepository
        {
            get => _facultyRepository ??= new FacultyRepository(context);}
        public IPostRepository postRepository { 
            get => _postRepository ??= new PostRepository(context); }
        public ISemesterRepository semesterRepository {
            get => _semesterRepository ??= new SemesterRepository(context); }
        public ISubjectRepository subjectRepository {
            get => _subjectRepository ??= new SubjectRepository(context);}
        public IUserRepository userRepository { 
            get => _userRepository ??= new UserRepository(context); }
        public IStudentRepository studentRepository {
            get => _studentRepository ??= new StudentRepository(context); }
        public ILecturerRepository lecturerRepository {
            get => _lecturerRepository ??= new LecturerRepository(context); }
        public ISchoolClassRepository schoolClassRepository{
               get => _schoolClassRepository ??= new SchoolClassRepository(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
