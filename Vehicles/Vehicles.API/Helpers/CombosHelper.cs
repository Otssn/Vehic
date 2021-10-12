using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data;

namespace Vehicles.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetCombosBrands()
        {
            List<SelectListItem> list = _dataContext.Brand.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una marca...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetCombosProcedures()
        {
            List<SelectListItem> list = _dataContext.Procedures.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
               .OrderBy(x => x.Text)
               .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un procedimiento...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetCombosDocumentTypes()
        {
            List<SelectListItem> list = _dataContext.DocumentTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de documento...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetCombosVehicleTypes()
        {
            List<SelectListItem> list = _dataContext.VehicleTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de vehículo...]",
                Value = "0"
            });

            return list;
        }
    }
}
