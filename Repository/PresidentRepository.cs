using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PresidentRepository{ 
    private readonly List<President> _presidents;

    public PresidentRepository()
    {
        // Initialize with sample data
        _presidents = new List<President>
        {
            new President
    {
        Id = 1,
        Name = "George Washington",
        Birthdate = new DateTime(1732, 2, 22),
        InaugurationDate = new DateTime(1789, 4, 30),
        TermCount = 2
    },
    new President
    {
        Id = 2,
        Name = "John Adams",
        Birthdate = new DateTime(1735, 10, 30),
        InaugurationDate = new DateTime(1797, 3, 4),
        TermCount = 1
    },
    new President
    {
        Id = 3,
        Name = "Thomas Jefferson",
        Birthdate = new DateTime(1743, 4, 13),
        InaugurationDate = new DateTime(1801, 3, 4),
        TermCount = 2
    },
    new President
    {
        Id = 4,
        Name = "James Madison",
        Birthdate =  new DateTime(1751, 3, 16),
        InaugurationDate = new DateTime(1809, 3, 4),
        TermCount = 2
    },
    new President
    {
        Id = 5,
        Name = "James Monroe",
        Birthdate = new DateTime(1758, 4, 28),
        InaugurationDate = new DateTime(1817, 3, 4),
        TermCount = 2
    },
    new President
    {
        Id = 6,
        Name = "John Quincy Adams",
        Birthdate = new DateTime(1767, 7, 11),
        InaugurationDate = new DateTime(1825, 3, 4),
        TermCount = 1
    },
    new President
    {
        Id = 7,
        Name = "Andrew Jackson",
        Birthdate = new DateTime(1767, 3, 15),
        InaugurationDate = new DateTime(1829, 3, 4),
        TermCount = 2
    },
    new President
    {
        Id = 8,
        Name = "Martin Van Buren",
        Birthdate = new DateTime(1782, 12, 5),
        InaugurationDate = new DateTime(1837, 3, 4),
        TermCount = 1
    },
    new President
    {
        Id = 9,
        Name = "William Henry Harrison",
        Birthdate = new DateTime(1773, 2, 9),
        InaugurationDate = new DateTime(1841, 3, 4),
        TermCount = 1
    },
    new President
    {
        Id = 10,
        Name = "John Tyler",
        Birthdate = new DateTime(1790, 3, 29),
        InaugurationDate = new DateTime(1841, 4, 6),
        TermCount = 1
    },
    new President
    {
        Id = 11,
        Name = "James K. Polk",
        Birthdate = new DateTime(1795, 11, 2),
        InaugurationDate = new DateTime(1845, 3, 4),
        TermCount = 1
    },
    new President
    {
        Id = 12,
        Name = "Zachary Taylor",
        Birthdate = new DateTime(1784, 11, 24),
        InaugurationDate = new DateTime(1849, 3, 5),
        TermCount = 1
    }
        };
    }

    public Task<IEnumerable<President>> GetPresidentsAsync()
    {
        return Task.FromResult(_presidents.AsEnumerable());
    }

    public Task<President> GetPresidentByIdAsync(int id)
    {
        var president = _presidents.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(president);
    }

    public Task AddPresidentAsync(President president)
    {
        president.Id = _presidents.Max(p => p.Id) + 1;
        _presidents.Add(president);
        return Task.CompletedTask;
    }

    public Task UpdatePresidentAsync(President president)
    {
        var existingPresident = _presidents.FirstOrDefault(p => p.Id == president.Id);
        if (existingPresident != null)
        {
            existingPresident.Name = president.Name;
            existingPresident.Birthdate = president.Birthdate;
            existingPresident.InaugurationDate = president.InaugurationDate;
            // Update other properties as needed
        }
        return Task.CompletedTask;
    }

    public Task DeletePresidentAsync(int id)
    {
        var president = _presidents.FirstOrDefault(p => p.Id == id);
        if (president != null)
        {
            _presidents.Remove(president);
        }
        return Task.CompletedTask;
    }
}

}
