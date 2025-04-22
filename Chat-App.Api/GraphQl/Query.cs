using Chat_App.Api.Data;
using Chat_App.Api.Entities;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.Extensions.Hosting;
namespace Chat_App.Api.GraphQl
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AppUser> GetUsers([Service] DataContext context) => context.Users;

    }
}