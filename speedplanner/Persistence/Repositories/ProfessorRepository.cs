using Microsoft.EntityFrameworkCore;
using speedplanner.Domain.Models;
using speedplanner.Domain.Persistence.Contexts;
using speedplanner.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Persistence.Repositories
{/*
    public class ProfessorRepository:BaseRepository, IProfessorRepository
    {
        public ProfessorRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Professor>> ListBySectionIdAsync(int sectionId)
        {
            return await _context.Professors.ToListAsync();
        }

        public async Task AddAsync(int sectionId, Professor professor)
        {
            professor.SectionId = sectionId;
            await _context.Professors.AddAsync(professor);
        }

        public async Task<Professor> FindById(int professorId)
        {
            return await _context.Professors.FindAsync(professorId);
        }

        public void Remove(Professor professor)
        {
            _context.Professors.Remove(professor);
        }

        public void Update(Professor professor)
        {
            _context.Professors.Update(professor);
        }
    }*/
}
