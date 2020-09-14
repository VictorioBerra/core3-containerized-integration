namespace DockerTemplate.Commands
{
    using Boxed.AspNetCore;
    using DockerTemplate.ViewModels;
    using Microsoft.AspNetCore.JsonPatch;

    public interface IPatchCarCommand : IAsyncCommand<int, JsonPatchDocument<SaveCar>>
    {
    }
}
