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


        public override IEnumerable<Transaction> GetAllData()
        {
           return _dbSet.AsEnumerable<Transaction>()
                .OrderByDescending(t => t.SetDate)
                .Take(20);
        }

        public bool IsTransactionCorrect(int id, int bankAccountId, string userId)
        {
            return _dbSet.AsNoTracking().Any(t => t.Id == id && t.Account.Id == bankAccountId && t.Account.User.Id == userId);
        }


        public IEnumerable<Transaction> GetAllData(int bankAcccountId)
        {
            return _dbSet.AsEnumerable<Transaction>()
                .Where(t => t.Account.Id == bankAcccountId)
                .OrderByDescending(t => t.SetDate);
        }

        public IEnumerable<Transaction> GetTransactionsByFilters(int bankAccount, DateTime? fromDate, DateTime? toDate, int? itemsForPage, string filterName, string filterValue)
        {
            var transaction = new Transaction();
            // Setting itemsForPage
            IEnumerable<Transaction> transactionsList = null;
            itemsForPage = itemsForPage ?? 20;

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
                                        .Where(t => t.Account.Id == bankAccount && t.Amount <= 0 && t.SetDate >= fromDate && t.SetDate <= toDate)
                                        .OrderByDescending(t => prop.GetValue(t, null))
                                        .Take(itemsForPage.Value);
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
                                        .Where(t => t.Account.Id == bankAccount && t.Amount <= 0 && t.SetDate >= fromDate && t.SetDate <= toDate)
                                        .OrderBy(t => prop.GetValue(t, null))
                                        .Take(itemsForPage.Value);
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
                                        .Where(t => t.Account.Id == bankAccount && t.Amount >= 0 && t.SetDate >= fromDate && t.SetDate <= toDate)
                                        .OrderByDescending(t => prop.GetValue(t, null))
                                        .Take(itemsForPage.Value);
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
                                        .Where(t => t.Account.Id == bankAccount && t.Amount >= 0 && t.SetDate >= fromDate && t.SetDate <= toDate)
                                        .OrderBy(t => prop.GetValue(t, null))
                                        .Take(itemsForPage.Value);
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
                                    .Where(t => t.Account.Id == bankAccount && t.SetDate >= fromDate && t.SetDate <= toDate)
                                    .OrderByDescending(t => prop.GetValue(t, null))
                                    .Take(itemsForPage.Value);
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
                                    .Where(t => t.Account.Id == bankAccount && t.SetDate >= fromDate && t.SetDate <= toDate)
                                    .OrderBy(t => prop.GetValue(t, null))
                                    .Take(itemsForPage.Value);
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
                        .Where(t => t.Account.Id == bankAccount && t.SetDate >= fromDate && t.SetDate <= toDate)
                        .OrderByDescending(t => t.SetDate)
                        .Take(itemsForPage.Value);
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
                                        .Where(t => t.Account.Id == bankAccount && t.Amount <= 0)
                                        .OrderByDescending(t => prop.GetValue(t, null))
                                        .Take(itemsForPage.Value);
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
                                        .Where(t => t.Account.Id == bankAccount && t.Amount <= 0)
                                        .OrderBy(t => prop.GetValue(t,null))
                                        .Take(itemsForPage.Value);
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
                                        .Where(t => t.Account.Id == bankAccount && t.Amount >= 0)
                                        .OrderByDescending(t => prop.GetValue(t, null))
                                        .Take(itemsForPage.Value);
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
                                        .Where(t => t.Account.Id == bankAccount && t.Amount >= 0)
                                        .OrderBy(t => prop.GetValue(t, null))
                                        .Take(itemsForPage.Value);
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
                                    .Where(t => t.Account.Id == bankAccount)
                                    .OrderByDescending(t => prop.GetValue(t, null))
                                    .Take(itemsForPage.Value);
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
                                    .Where(t => t.Account.Id == bankAccount)
                                    .OrderBy(t => prop.GetValue(t, null))
                                    .Take(itemsForPage.Value);
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
                        .Where(t => t.Account.Id == bankAccount)
                        .OrderByDescending(t => t.SetDate)
                        .Take(itemsForPage.Value);
                }
            }

            return transactionsList;
        }
    }
}
