using CatCards.Models;
using System.Collections.Generic;

namespace CatCards.DAO
{
    public interface ICatCardDao
    {
        List<CatCard> GetAllCards();
        CatCard GetCard(int id);
        CatCard AddCard(CatCard addedCard);
        bool UpdateCard(CatCard updatedCard);
        bool RemoveCard(int id);
        CatCard GetRandomCatCard();
    }
}