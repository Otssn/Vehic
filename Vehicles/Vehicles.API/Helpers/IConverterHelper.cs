using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;
using Vehicles.API.Views;

namespace Vehicles.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViweModel model, Guid imageId, bool isNew);

        UserViweModel ToUserViewModel(User user);
    }
}
