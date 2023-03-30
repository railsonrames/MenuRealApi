using MenuRealApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MenuRealApi.Services.RestaurantService
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAll();
        Restaurant Get(Guid id);
        List<Restaurant> Create(Restaurant request);
        Restaurant Update(Guid id, [FromBody] Restaurant request);
        List<Restaurant> Delete(Guid id);
    }
}
