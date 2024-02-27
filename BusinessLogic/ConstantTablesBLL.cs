using DataAccess.Entity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Net;
using BusinessLogic.Models.Response;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusinessLogic
{
    public class ConstantTablesBLL
    {
        private readonly ConstantTablesDAL _repository;
        public ConstantTablesBLL(ConstantTablesDAL repository)
        {
            _repository = repository;
        }

        public IEnumerable<ConstantTables> Department()
        {
            try
            {
                return _repository.Department();
            }
            catch (Exception)
            {
                throw new Exception($"Error retrieving Department");
            }
        }
        public IEnumerable<ConstantTables> Gender()
        {
            try
            {
                return _repository.Gender();
            }
            catch (Exception)
            {
                throw new Exception($"Error retrieving Gender");
            }
        }
        public IEnumerable<ConstantTables> Provinces()
        {
            try
            {
                return _repository.Provinces();
            }
            catch (Exception)
            {
                throw new Exception($"Error retrieving Provinces");
            }
        }
        public IEnumerable<ConstantTables> Race()
        {
            try
            {
                return _repository.Race();
            }
            catch (Exception)
            {
                throw new Exception($"Error retrieving Race");
            }
        }
    }
}
