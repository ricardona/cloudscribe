﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:				    2008-01-04
// Last Modified:			2015-11-18
// 

using cloudscribe.DbHelpers.MSSQL;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace cloudscribe.Core.Repositories.MSSQL
{
    internal class DBUserLocation
    {
        internal DBUserLocation(
            string dbReadConnectionString,
            string dbWriteConnectionString,
            ILoggerFactory loggerFactory)
        {
            logFactory = loggerFactory;
            readConnectionString = dbReadConnectionString;
            writeConnectionString = dbWriteConnectionString;
        }

        private ILoggerFactory logFactory;
        //private ILogger log;
        private string readConnectionString;
        private string writeConnectionString;

        /// <summary>
        /// Inserts a row in the mp_UserLocation table. Returns rows affected count.
        /// </summary>
        /// <param name="rowID"> rowID </param>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="siteGuid"> siteGuid </param>
        /// <param name="iPAddress"> iPAddress </param>
        /// <param name="iPAddressLong"> iPAddressLong </param>
        /// <param name="hostname"> hostname </param>
        /// <param name="longitude"> longitude </param>
        /// <param name="latitude"> latitude </param>
        /// <param name="iSP"> iSP </param>
        /// <param name="continent"> continent </param>
        /// <param name="country"> country </param>
        /// <param name="region"> region </param>
        /// <param name="city"> city </param>
        /// <param name="timeZone"> timeZone </param>
        /// <param name="captureCount"> captureCount </param>
        /// <param name="firstCaptureUTC"> firstCaptureUTC </param>
        /// <param name="lastCaptureUTC"> lastCaptureUTC </param>
        /// <returns>int</returns>
        public int Create(
            Guid rowID,
            Guid userGuid,
            Guid siteGuid,
            string iPAddress,
            long iPAddressLong,
            string hostname,
            double longitude,
            double latitude,
            string iSP,
            string continent,
            string country,
            string region,
            string city,
            string timeZone,
            int captureCount,
            DateTime firstCaptureUTC,
            DateTime lastCaptureUTC)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                writeConnectionString, 
                "mp_UserLocation_Insert", 
                17);

            sph.DefineSqlParameter("@RowID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, rowID);
            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            sph.DefineSqlParameter("@SiteGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, siteGuid);
            sph.DefineSqlParameter("@IPAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, iPAddress);
            sph.DefineSqlParameter("@IPAddressLong", SqlDbType.BigInt, ParameterDirection.Input, iPAddressLong);
            sph.DefineSqlParameter("@Hostname", SqlDbType.NVarChar, 255, ParameterDirection.Input, hostname);
            sph.DefineSqlParameter("@Longitude", SqlDbType.Float, ParameterDirection.Input, longitude);
            sph.DefineSqlParameter("@Latitude", SqlDbType.Float, ParameterDirection.Input, latitude);
            sph.DefineSqlParameter("@ISP", SqlDbType.NVarChar, 255, ParameterDirection.Input, iSP);
            sph.DefineSqlParameter("@Continent", SqlDbType.NVarChar, 255, ParameterDirection.Input, continent);
            sph.DefineSqlParameter("@Country", SqlDbType.NVarChar, 255, ParameterDirection.Input, country);
            sph.DefineSqlParameter("@Region", SqlDbType.NVarChar, 255, ParameterDirection.Input, region);
            sph.DefineSqlParameter("@City", SqlDbType.NVarChar, 255, ParameterDirection.Input, city);
            sph.DefineSqlParameter("@TimeZone", SqlDbType.NVarChar, 255, ParameterDirection.Input, timeZone);
            sph.DefineSqlParameter("@CaptureCount", SqlDbType.Int, ParameterDirection.Input, captureCount);
            sph.DefineSqlParameter("@FirstCaptureUTC", SqlDbType.DateTime, ParameterDirection.Input, firstCaptureUTC);
            sph.DefineSqlParameter("@LastCaptureUTC", SqlDbType.DateTime, ParameterDirection.Input, lastCaptureUTC);
            int rowsAffected = sph.ExecuteNonQuery();
            return rowsAffected;
        }


        /// <summary>
        /// Updates a row in the mp_UserLocation table. Returns true if row updated.
        /// </summary>
        /// <param name="rowID"> rowID </param>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="siteGuid"> siteGuid </param>
        /// <param name="iPAddress"> iPAddress </param>
        /// <param name="iPAddressLong"> iPAddressLong </param>
        /// <param name="hostname"> hostname </param>
        /// <param name="longitude"> longitude </param>
        /// <param name="latitude"> latitude </param>
        /// <param name="iSP"> iSP </param>
        /// <param name="continent"> continent </param>
        /// <param name="country"> country </param>
        /// <param name="region"> region </param>
        /// <param name="city"> city </param>
        /// <param name="timeZone"> timeZone </param>
        /// <param name="captureCount"> captureCount </param>
        /// <param name="lastCaptureUTC"> lastCaptureUTC </param>
        /// <returns>bool</returns>
        public bool Update(
            Guid rowID,
            Guid userGuid,
            Guid siteGuid,
            string iPAddress,
            long iPAddressLong,
            string hostname,
            double longitude,
            double latitude,
            string iSP,
            string continent,
            string country,
            string region,
            string city,
            string timeZone,
            int captureCount,
            DateTime lastCaptureUTC)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                writeConnectionString, 
                "mp_UserLocation_Update", 
                16);

            sph.DefineSqlParameter("@RowID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, rowID);
            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            sph.DefineSqlParameter("@SiteGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, siteGuid);
            sph.DefineSqlParameter("@IPAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, iPAddress);
            sph.DefineSqlParameter("@IPAddressLong", SqlDbType.BigInt, ParameterDirection.Input, iPAddressLong);
            sph.DefineSqlParameter("@Hostname", SqlDbType.NVarChar, 255, ParameterDirection.Input, hostname);
            sph.DefineSqlParameter("@Longitude", SqlDbType.Float, ParameterDirection.Input, longitude);
            sph.DefineSqlParameter("@Latitude", SqlDbType.Float, ParameterDirection.Input, latitude);
            sph.DefineSqlParameter("@ISP", SqlDbType.NVarChar, 255, ParameterDirection.Input, iSP);
            sph.DefineSqlParameter("@Continent", SqlDbType.NVarChar, 255, ParameterDirection.Input, continent);
            sph.DefineSqlParameter("@Country", SqlDbType.NVarChar, 255, ParameterDirection.Input, country);
            sph.DefineSqlParameter("@Region", SqlDbType.NVarChar, 255, ParameterDirection.Input, region);
            sph.DefineSqlParameter("@City", SqlDbType.NVarChar, 255, ParameterDirection.Input, city);
            sph.DefineSqlParameter("@TimeZone", SqlDbType.NVarChar, 255, ParameterDirection.Input, timeZone);
            sph.DefineSqlParameter("@CaptureCount", SqlDbType.Int, ParameterDirection.Input, captureCount);
            sph.DefineSqlParameter("@LastCaptureUTC", SqlDbType.DateTime, ParameterDirection.Input, lastCaptureUTC);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        /// <summary>
        /// Deletes a row from the mp_UserLocation table. Returns true if row deleted.
        /// </summary>
        /// <param name="rowID"> rowID </param>
        /// <returns>bool</returns>
        public bool Delete(Guid rowID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                writeConnectionString, 
                "mp_UserLocation_Delete", 
                1);

            sph.DefineSqlParameter("@RowID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, rowID);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        public bool DeleteByUser(Guid userGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                writeConnectionString, 
                "mp_UserLocation_DeleteByUser", 
                1);

            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_UserLocation table.
        /// </summary>
        /// <param name="rowID"> rowID </param>
        public DbDataReader GetOne(Guid rowID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_SelectOne", 
                1);

            sph.DefineSqlParameter("@RowID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, rowID);
            return sph.ExecuteReader();
        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_UserLocation table.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="iPAddress"> iPAddress </param>
        public DbDataReader GetOne(Guid userGuid, long iPAddressLong)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_SelectOneByUserAndIP", 
                2);

            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            sph.DefineSqlParameter("@IPAddressLong", SqlDbType.BigInt, ParameterDirection.Input, iPAddressLong);
            return sph.ExecuteReader();
        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_UserLocation table.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        public DbDataReader GetByUser(Guid userGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_SelectByUser", 
                1);

            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            return sph.ExecuteReader();
        }



        /// <summary>
        /// Gets an IDataReader with one row from the mp_UserLocation table.
        /// </summary>
        /// <param name="siteGuid"> siteGuid </param>
        public DbDataReader GetBySite(Guid siteGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_SelectBySite", 
                1);

            sph.DefineSqlParameter("@SiteGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, siteGuid);
            return sph.ExecuteReader();
        }

        /// <summary>
        /// Gets an IDataReader with rows from the mp_Users table which have the passed in IP Address
        /// </summary>
        /// <param name="siteGuid"> siteGuid </param>
        public async Task<DbDataReader> GetUsersByIPAddress(Guid siteGuid, string ipv4Address)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_SelectUsersByIP", 
                2);

            sph.DefineSqlParameter("@SiteGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, siteGuid);
            sph.DefineSqlParameter("@IPAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, ipv4Address);
            return await sph.ExecuteReaderAsync();
        }

        /// <summary>
        /// Gets a count of rows in the mp_UserLocation table for the passed in userGuid.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        public int GetCountByUser(Guid userGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_GetCountByUser", 
                1);

            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            return Convert.ToInt32(sph.ExecuteScalar());


        }

        ///// <summary>
        ///// Returns true if the given userguid/ip is found
        ///// </summary>
        ///// <param name="userGuid"> userGuid </param>
        //public static bool Exists(Guid userGuid, long ipAsLong)
        //{
        //    SqlParameterHelper sph = new SqlParameterHelper(GetConnectionString(), "mp_UserLocation_Exists", 1);
        //    sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
        //    return Convert.ToInt32(sph.ExecuteScalar()) > 0;

        //}

        /// <summary>
        /// Gets a count of rows in the mp_UserLocation table for the passed in userGuid.
        /// </summary>
        /// <param name="siteGuid"> siteGuid </param>
        public int GetCountBySite(Guid siteGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_GetCountBySite", 
                1);

            sph.DefineSqlParameter("@SiteGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, siteGuid);
            return Convert.ToInt32(sph.ExecuteScalar());


        }



        /// <summary>
        /// Gets a page of data from the mp_UserLocation table.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public DbDataReader GetPageByUser(
            Guid userGuid,
            int pageNumber,
            int pageSize)
        {
            //totalPages = 1;
            //int totalRows
            //    = GetCountByUser(userGuid);

            //if (pageSize > 0) totalPages = totalRows / pageSize;

            //if (totalRows <= pageSize)
            //{
            //    totalPages = 1;
            //}
            //else
            //{
            //    int remainder;
            //    Math.DivRem(totalRows, pageSize, out remainder);
            //    if (remainder > 0)
            //    {
            //        totalPages += 1;
            //    }
            //}

            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_SelectPageByUser", 
                3);

            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }

        /// <summary>
        /// Gets a page of data from the mp_UserLocation table.
        /// </summary>
        /// <param name="siteGuid"> siteGuid </param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public DbDataReader GetPageBySite(
            Guid siteGuid,
            int pageNumber,
            int pageSize)
        {
            //totalPages = 1;
            //int totalRows
            //    = GetCountBySite(siteGuid);

            //if (pageSize > 0) totalPages = totalRows / pageSize;

            //if (totalRows <= pageSize)
            //{
            //    totalPages = 1;
            //}
            //else
            //{
            //    int remainder;
            //    Math.DivRem(totalRows, pageSize, out remainder);
            //    if (remainder > 0)
            //    {
            //        totalPages += 1;
            //    }
            //}

            SqlParameterHelper sph = new SqlParameterHelper(
                logFactory,
                readConnectionString, 
                "mp_UserLocation_SelectPageBySite", 
                3);

            sph.DefineSqlParameter("@SiteGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, siteGuid);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }


    }

}
