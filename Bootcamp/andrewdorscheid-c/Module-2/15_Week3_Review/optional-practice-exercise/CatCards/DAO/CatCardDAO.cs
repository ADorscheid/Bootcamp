using CatCards.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CatCards.DAO
{
    /// <summary>
    /// This class takes care of all data access for a CatCard. This includes:
    ///     1. Database access for adding, updating, reading and deleting user-saved cards
    ///     2. Generation of a new CatCard card by assembling random cat facts and random cat pictures retrieved from an api
    /// </summary>
    public class CatCardDAO : ICatCardDao
    {
        private readonly string connectionString;
        private readonly string catFactApiUrl = "https://cat-fact.herokuapp.com/facts/random";
        private readonly string catPicApiUrl = "https://random-cat-image.herokuapp.com/";

        /// <summary>
        /// Constructor.  Needs a connection string to connect to a database.
        /// </summary>
        public CatCardDAO()
        {
        }

        /// <summary>
        /// Saves a new card to the database in the user's collection
        /// </summary>
        /// <param name="addedCard">The new card to add</param>
        /// <returns>The added card</returns>
        public CatCard AddCard(CatCard addedCard)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List all cards in the DB
        /// </summary>
        /// <returns>A list of all saved CatCards.</returns>
        public List<CatCard> GetAllCards()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a single CatCard from the DB based on an id
        /// </summary>
        /// <param name="id">Id of the card to read</param>
        /// <returns>The card with the specified id, NULL if there is no such id</returns>
        public CatCard GetCard(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Use two API's to get a Cat Fact and a Cat Card and assemble a new CatCard.  This method does not
        /// read from or write to the database.
        /// </summary>
        /// <returns></returns>
        public CatCard GetRandomCatCard()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes from the DB the card with the specified id
        /// </summary>
        /// <param name="id">Id of the card to delete</param>
        /// <returns>True if the delete succeeded</returns>
        public bool RemoveCard(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the properties of the card in the DB. 
        /// </summary>
        /// <param name="updatedCard">New values to save into the DB</param>
        /// <returns>True if the update succeeded</returns>
        public bool UpdateCard(CatCard updatedCard)
        {
            throw new NotImplementedException();
        }
    }
}