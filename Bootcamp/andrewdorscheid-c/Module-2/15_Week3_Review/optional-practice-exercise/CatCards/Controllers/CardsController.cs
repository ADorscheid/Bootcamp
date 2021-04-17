using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    /// <summary>
    /// This is our api controller.  It serves these endpoints:
    /// 
    ///  GET    /api/cards          Provides a list of all Cat Cards in the user's collection.
    ///  GET    /api/cards/{id}     Provides a Cat Card with the given ID.
    ///  GET    /api/cards/random   Provides a new, randomly created Cat Card containing information from the cat fact and picture services.
    ///  POST   /api/cards          Saves a card to the user's collection.
    ///  PUT    /api/cards          Updates a card in the user's collection.
    ///  DELETE /api/cards          Removes a card from the user's collection.
    ///  
    /// </summary>
    [ApiController]
    public class CardsController : ControllerBase
    {
        public CardsController()
        {
        }

    }
}
