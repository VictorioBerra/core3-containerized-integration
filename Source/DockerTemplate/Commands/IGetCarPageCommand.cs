namespace DockerTemplate.Commands
{
    using Boxed.AspNetCore;
    using DockerTemplate.ViewModels;

    public interface IGetCarPageCommand : IAsyncCommand<PageOptions>
    {
    }
}
