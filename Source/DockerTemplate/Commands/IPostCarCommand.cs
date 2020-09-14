namespace DockerTemplate.Commands
{
    using Boxed.AspNetCore;
    using DockerTemplate.ViewModels;

    public interface IPostCarCommand : IAsyncCommand<SaveCar>
    {
    }
}
