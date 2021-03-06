﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using MMM.BussinesLogic;
using MMM.Model;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public class TransactionReadRepository : ReadRepository<Transaction>, ITransactionReadRepository
    {
        public TransactionReadRepository(DbContext ctx) : base(ctx)
        {
            
        }

        public Transaction GetTransactionById(string transactionId, string bankAccountId)
        {
            return _dbSet.SingleOrDefault(t => t.Id == transactionId && t.BankAccount.Id == bankAccountId);
        }

        public override IEnumerable<Transaction> GetAllData()
        {
            return _dbSet.AsEnumerable<Transaction>()
                .OrderByDescending(t => t.SetDate);
        }

        public bool IsTransactionCorrect(string transactionId, string bankAccountId, string userId)
        {
            return _dbSet.AsNoTracking().Any(t => t.Id == transactionId && t.BankAccount.Id == bankAccountId && t.BankAccount.User.Id == userId);
        }


        public IEnumerable<Transaction> GetAllData(string bankAcccountId)
        {
            return _dbSet.AsEnumerable<Transaction>()
                .Where(t => t.BankAccount.Id == bankAcccountId)
                .OrderByDescending(t => t.SetDate);
        }

        public IEnumerable<Transaction> GetTransactionsByFilters(string bankAccountId, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue)
        {
            var transaction = new Transaction();
            // Setting itemsForPage
            IEnumerable<Transaction> transactionsList = null;

            // fromDate, toDate have values
            if (fromDate != null && toDate != null)
            {
                // filterName, filterValue have values
                if (!(String.IsNullOrEmpty(filterName)) || !(String.IsNullOrEmpty(filterValue)))
                {
                    var filter = new Filter<Transaction>();
                    // is filterName Amount
                    if (filter.CheckIfFilterIsAmount(filterName))
                    {
                        if (filter.CheckIfAmountIsNegative(filterName))
                        // is -Amount 
                        {
                            // encode -Amount
                            filterName = filter.EncodeAmountFilter(filterName);
                            var prop = transaction.GetType().GetProperty(filter.GetPropertyName(filterName));

                            if (filterValue == "desc")
                            {
                                try
                                {
                                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                                        .Where(t => t.BankAccount.Id == bankAccountId && t.Amount <= 0 &&
                                                    t.SetDate >= fromDate && t.SetDate <= toDate)
                                        .OrderByDescending(t => prop.GetValue(t, null));
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            }
                            if (filterValue == "asc")
                            {
                                try
                                {
                                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                                        .Where(t => t.BankAccount.Id == bankAccountId && t.Amount <= 0 &&
                                                    t.SetDate >= fromDate && t.SetDate <= toDate)
                                        .OrderBy(t => prop.GetValue(t, null));
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            }
                        }
                        // is +Amount
                        if (filter.CheckIfAmountIsPositive(filterName))
                        {
                            // encode +Amount
                            filterName = filter.EncodeAmountFilter(filterName);
                            var prop = transaction.GetType().GetProperty(filter.GetPropertyName(filterName));

                            if (filterValue == "desc")
                            {
                                try
                                {
                                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                                        .Where(t => t.BankAccount.Id == bankAccountId && t.Amount >= 0 &&
                                                    t.SetDate >= fromDate && t.SetDate <= toDate)
                                        .OrderByDescending(t => prop.GetValue(t, null));
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            }
                            if (filterValue == "asc")
                            {
                                try
                                {
                                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                                        .Where(t => t.BankAccount.Id == bankAccountId && t.Amount >= 0 &&
                                                    t.SetDate >= fromDate && t.SetDate <= toDate)
                                        .OrderBy(t => prop.GetValue(t, null));
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            }
                        }
                    }
                    // filterName is not Amount
                    else
                    {
                        var prop = transaction.GetType().GetProperty(filter.GetPropertyName(filterName));

                        if (filterValue == "desc")
                        {
                            try
                            {
                                transactionsList = _dbSet.AsEnumerable<Transaction>()
                                    .Where(t => t.BankAccount.Id == bankAccountId && t.SetDate >= fromDate &&
                                                t.SetDate <= toDate)
                                    .OrderByDescending(t => prop.GetValue(t, null));
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                        if (filterValue == "asc")
                        {
                            try
                            {
                                transactionsList = _dbSet.AsEnumerable<Transaction>()
                                    .Where(t => t.BankAccount.Id == bankAccountId && t.SetDate >= fromDate &&
                                                t.SetDate <= toDate)
                                    .OrderBy(t => prop.GetValue(t, null));
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                    }
                }
                // filterName, filterValue have no values
                else
                {
                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                        .Where(t => t.BankAccount.Id == bankAccountId && t.SetDate >= fromDate && t.SetDate <= toDate)
                        .OrderByDescending(t => t.SetDate);
                }

            }
            // fromDate, toDate have no values
            else
            {
                // filterName, filterValue have values
                if (!(String.IsNullOrEmpty(filterName)) || !(String.IsNullOrEmpty(filterValue)))
                {
                    var filter = new Filter<Transaction>();
                    // is filterName Amount
                    if (filter.CheckIfFilterIsAmount(filterName))
                    {
                        // is -Amount
                        if (filter.CheckIfAmountIsNegative(filterName))
                        {
                            // encode -Amount
                            filterName = filter.EncodeAmountFilter(filterName);
                            var prop = transaction.GetType().GetProperty(filter.GetPropertyName(filterName));

                            if (filterValue == "desc")
                            {
                                try
                                {
                                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                                        .Where(t => t.BankAccount.Id == bankAccountId && t.Amount <= 0)
                                        .OrderByDescending(t => prop.GetValue(t, null));
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            }
                            if (filterValue == "asc")
                            {
                                try
                                {
                                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                                        .Where(t => t.BankAccount.Id == bankAccountId && t.Amount <= 0)
                                        .OrderBy(t => prop.GetValue(t, null));
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            }
                        }
                        // is +Amount
                        if (filter.CheckIfAmountIsPositive(filterName))
                        {
                            // encode +Amount
                            filterName = filter.EncodeAmountFilter(filterName);
                            var prop = transaction.GetType().GetProperty(filter.GetPropertyName(filterName));

                            if (filterValue == "desc")
                            {
                                try
                                {
                                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                                        .Where(t => t.BankAccount.Id == bankAccountId && t.Amount >= 0)
                                        .OrderByDescending(t => prop.GetValue(t, null));
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            }
                            if (filterValue == "asc")
                            {
                                try
                                {
                                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                                        .Where(t => t.BankAccount.Id == bankAccountId && t.Amount >= 0)
                                        .OrderBy(t => prop.GetValue(t, null));
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            }
                        }
                    }
                    // filterName is not Amount
                    else
                    {
                        var prop = transaction.GetType().GetProperty(filter.GetPropertyName(filterName));

                        if (filterValue == "desc")
                        {

                            try
                            {
                                transactionsList = _dbSet.AsEnumerable<Transaction>()
                                    .Where(t => t.BankAccount.Id == bankAccountId)
                                    .OrderByDescending(t => prop.GetValue(t, null));
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                        if (filterValue == "asc")
                        {
                            try
                            {
                                transactionsList = _dbSet.AsEnumerable<Transaction>()
                                    .Where(t => t.BankAccount.Id == bankAccountId)
                                    .OrderBy(t => prop.GetValue(t, null));
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                    }

                }
                // filterName, filterValue have no values
                else
                {
                    transactionsList = _dbSet.AsEnumerable<Transaction>()
                        .Where(t => t.BankAccount.Id == bankAccountId)
                        .OrderByDescending(t => t.SetDate);
                }
            }

            return transactionsList;
        }

    }
}
