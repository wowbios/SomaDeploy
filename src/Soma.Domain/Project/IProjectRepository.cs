namespace Soma.Domain.Project;

public interface IProjectRepository
{
    Task<IProject?> Get(long id);

    Task<IProject> Create(string name);
}