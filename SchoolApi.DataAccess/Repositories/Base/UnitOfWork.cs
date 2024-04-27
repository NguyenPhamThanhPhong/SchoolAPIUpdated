using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.InformationTypeGroups;
using SchoolApi.Infrastructure.Repositories.UserGroups;


namespace SchoolApi.Infrastructure.Repositories.Base
{

    public class UnitOfWork : IDisposable
    {
        private readonly SchoolDbContext _context;
#pragma warning disable CS8618
        public UnitOfWork(SchoolDbContext context)
        {
            _context = context;
        }
#pragma warning restore CS8618

        private IFacultyRepository  _facultyRepository  ;
        private IPostRepository     _postRepository     ;
        private ISemesterRepository _semesterRepository ;
        private ISubjectRepository  _subjectRepository  ;
        private IUserRepository     _userRepository     ;
        private IStudentRepository  _studentRepository  ;
        private ILecturerRepository _lecturerRepository ;


        public IFacultyRepository facultyRepository
        {
            get => _facultyRepository ??= new FacultyRepository(_context);}
        public IPostRepository postRepository { 
            get => _postRepository ??= new PostRepository(_context); }
        public ISemesterRepository semesterRepository {
            get => _semesterRepository ??= new SemesterRepository(_context); }
        public ISubjectRepository subjectRepository {
            get => _subjectRepository ??= new SubjectRepository(_context);}
        public IUserRepository userRepository { 
            get => _userRepository ??= new UserRepository(_context); }
        public IStudentRepository studentRepository {
            get => _studentRepository ??= new StudentRepository(_context); }
        public ILecturerRepository lecturerRepository {
            get => _lecturerRepository ??= new LecturerRepository(_context); }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
