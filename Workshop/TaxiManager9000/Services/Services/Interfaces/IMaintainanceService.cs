﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Services.Services.Interfaces
{
    public interface IMaintainanceService
    {
        List<Car> ListAllCars();
    }
}
