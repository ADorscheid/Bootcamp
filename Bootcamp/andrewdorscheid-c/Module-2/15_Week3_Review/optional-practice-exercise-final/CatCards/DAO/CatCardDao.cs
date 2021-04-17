using CatCards.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CatCards.DAO
{
    public class CatCardDao : ICatCardDao
    {
        private readonly string connectionString;
        private readonly string catFactApiUrl = "https://cat-fact.herokuapp.com/facts/random";
        private readonly string catPicApiUrl = "https://random-cat-image.herokuapp.com/";


        public CatCardDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<CatCard> GetAllCards()
        {
            List<CatCard> returnCards = new List<CatCard>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT id, img_url, fact, caption FROM catcards", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CatCard cc = GetCatCardFromReader(reader);
                        returnCards.Add(cc);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnCards;
        }

        public CatCard GetCard(int id)
        {
            CatCard returnCard = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT id, img_url, fact, caption FROM catcards WHERE id = @card_id", conn);
                    cmd.Parameters.AddWithValue("@card_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnCard = GetCatCardFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnCard;
        }

        public CatCard AddCard(CatCard addedCard)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO catcards (img_url, fact, caption) VALUES (@img_url, @fact, @caption); SELECT @@IDENTITY", conn);
                    cmd.Parameters.AddWithValue("@img_url", addedCard.ImgUrl);
                    cmd.Parameters.AddWithValue("@fact", addedCard.CatFact);
                    cmd.Parameters.AddWithValue("@caption", addedCard.Caption);

                    int newId = Convert.ToInt32(cmd.ExecuteScalar());

                    addedCard.CatCardId = newId;
                    return addedCard;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool UpdateCard(CatCard updatedCard)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE catcards SET img_url = @img_url, fact = @fact, caption = @caption WHERE id = @card_id", conn);
                    cmd.Parameters.AddWithValue("@img_url", updatedCard.ImgUrl);
                    cmd.Parameters.AddWithValue("@fact", updatedCard.CatFact);
                    cmd.Parameters.AddWithValue("@caption", updatedCard.Caption);
                    cmd.Parameters.AddWithValue("@card_id", updatedCard.CatCardId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool RemoveCard(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM catcards WHERE id = @card_id", conn);
                    cmd.Parameters.AddWithValue("@card_id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private CatCard GetCatCardFromReader(SqlDataReader reader)
        {
            CatCard c = new CatCard()
            {
                CatCardId = Convert.ToInt32(reader["id"]),
                ImgUrl = Convert.ToString(reader["img_url"]),
                CatFact = Convert.ToString(reader["fact"]),
                Caption = Convert.ToString(reader["caption"])
            };

            return c;
        }

        public CatCard GetRandomCatCard()
        {
            CatFact fact = GetFact();
            CatPic pic = GetPic();

            if (fact == null || pic == null)
            {
                return null;
            }

            CatCard card = new CatCard()
            {
                CatFact = fact.Text,
                ImgUrl = pic.File
            };

            return card;
        }
        private CatFact GetFact()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(catFactApiUrl);
            IRestResponse<CatFact> response = client.Get<CatFact>(request);
            if (response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }

        private CatPic GetPic()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(catPicApiUrl);
            IRestResponse<CatPic> response = client.Get<CatPic>(request);
            if (response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }
    }
}