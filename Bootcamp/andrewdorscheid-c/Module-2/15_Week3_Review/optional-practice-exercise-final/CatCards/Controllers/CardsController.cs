using System.Collections.Generic;
using CatCards.DAO;
using CatCards.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    [Route("/api/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICatCardDao cardDAO;

        public CardsController(ICatCardDao cardDAO)
        {
            this.cardDAO = cardDAO;
        }

        public ActionResult<List<CatCard>> GetAllCards()
        {
            return Ok(cardDAO.GetAllCards());
        }

        [HttpGet("{id}")]
        public ActionResult<CatCard> GetCard(int id)
        {
            CatCard card = cardDAO.GetCard(id);
            if (card != null)
            {
                return Ok(card);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("random")]
        public ActionResult<CatCard> GetRandomCard()
        {
            CatCard card = cardDAO.GetRandomCatCard();
            if (card == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(card);
            }
        }

        [HttpPost]
        public ActionResult<CatCard> SaveCard(CatCard incomingCard)
        {
            CatCard newCard = cardDAO.AddCard(incomingCard);
            return Created("/api/cards/" + newCard.CatCardId, newCard);
        }

        [HttpPut("{id}")]
        public ActionResult<CatCard> UpdateExistingCard(int id, CatCard changedCard)
        {
            if (cardDAO.GetCard(id) != null)
            {
                if (changedCard.CatCardId == 0)
                {
                    changedCard.CatCardId = id;
                }
                return Ok(cardDAO.UpdateCard(changedCard));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExistingCard(int id)
        {
            if (cardDAO.GetCard(id) != null)
            {
                if (cardDAO.RemoveCard(id))
                {
                    return NoContent();
                }
            }
            else
            {
                return NotFound();
            }
            return BadRequest();
        }
    }
}
