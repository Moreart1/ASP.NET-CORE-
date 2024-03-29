﻿using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL;
using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly MyDbContext _context;

        public BankAccountRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task Add()
        {
            var bankAccount = new BankAccount();
            _context.Add(bankAccount.Create());
            await _context.SaveChangesAsync();
        }

        public async Task Close(BankAccount entity)
        {
            var bankAccount = await _context.BankAccount.OrderBy(en => en.BankAccountId==entity.BankAccountId).LastOrDefaultAsync();
            if (bankAccount == null)
            {
                throw new ArgumentException("Данные по счету отсутствуют", entity.BankAccountId.ToString());
            }
            bankAccount.Close(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<BankAccount>> Get()
        {
            var bankAccount = await _context.BankAccount.ToListAsync();
            return bankAccount;
        }

        public async Task Operation(BankAccount entity)
        {
            var bankAccount = await _context.BankAccount.OrderBy(en => en.BankAccountId == entity.BankAccountId).LastOrDefaultAsync();
            if (bankAccount == null)
            {
                throw new ArgumentException("Данные по счету отсутствуют", entity.BankAccountId.ToString());
            }
            bankAccount.Close(entity);
            await _context.SaveChangesAsync();
        }
    }
}
