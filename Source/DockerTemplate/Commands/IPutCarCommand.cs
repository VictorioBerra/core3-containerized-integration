namespace DockerTemplate.Commands
{
    using Boxed.AspNetCore;
    using DockerTemplate.ViewModels;

    public interface IPutCarCommand : IAsyncCommand<int, SaveCar>
    {
    }
}
