using SQLInjection.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLInjection.DAL
{
    public interface IPlayerDAO
    {
        IList<Player> SearchPlayer(string name);
    }
}
