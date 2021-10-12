using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data;
using Vehicles.API.Helpers;
using Vehicles.API.Views;

namespace Vehicles.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IBlobHelper _blobHelper;

        public UserController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper, IConverterHelper converterHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _blobHelper = blobHelper;
        } 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users
                .Include(x => x.DocumentType)
                .Include(x => x.Vehicles)
                .Where(x => x.userType == commons.Enums.UserType.User)
                .ToListAsync());
        }
        public IActionResult Create()
        {
            UserViweModel model = new UserViweModel
            {
                DocumentTypes = _combosHelper.GetCombosDocumentTypes()
            };

            return View(model);
        }
    }
}
