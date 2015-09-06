/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using Npgsql;
using PetaPoco;
using Serilog;

namespace MixERP.Net.Schemas.Core.Data
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "core.shipping_package_shapes".
    /// </summary>
    public class ShippingPackageShape : DbAccess
    {
        /// <summary>
        /// The schema of this table. Returns literal "core".
        /// </summary>
	    public override string ObjectNamespace => "core";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "shipping_package_shapes".
        /// </summary>
	    public override string ObjectName => "shipping_package_shapes";

        /// <summary>
        /// Login id of application user accessing this table.
        /// </summary>
		public long LoginId { get; set; }

        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string Catalog { get; set; }

		/// <summary>
		/// Performs SQL count on the table "core.shipping_package_shapes".
		/// </summary>
		/// <returns>Returns the number of rows of the table "core.shipping_package_shapes".</returns>
		public long Count()
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return 0;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT COUNT(*) FROM core.shipping_package_shapes;";
			return Factory.Scalar<long>(this.Catalog, sql);
		}

		/// <summary>
		/// Executes a select query on the table "core.shipping_package_shapes" with a where filter on the column "shipping_package_shape_id" to return a single instance of the "ShippingPackageShape" class. 
		/// </summary>
		/// <param name="shippingPackageShapeId">The column "shipping_package_shape_id" parameter used on where filter.</param>
		/// <returns>Returns a non-live, non-mapped instance of "ShippingPackageShape" class mapped to the database row.</returns>
		public MixERP.Net.Entities.Core.ShippingPackageShape Get(int shippingPackageShapeId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get entity \"ShippingPackageShape\" filtered by \"ShippingPackageShapeId\" with value {ShippingPackageShapeId} was denied to the user with Login ID {LoginId}", shippingPackageShapeId, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT * FROM core.shipping_package_shapes WHERE shipping_package_shape_id=@0;";
			return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this.Catalog, sql, shippingPackageShapeId).FirstOrDefault();
		}

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of core.shipping_package_shapes.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table core.shipping_package_shapes</returns>
		public IEnumerable<DisplayField> GetDisplayFields()
		{
			List<DisplayField> displayFields = new List<DisplayField>();

			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return displayFields;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get display field for entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT shipping_package_shape_id AS key, shipping_package_shape_code || ' (' || shipping_package_shape_name || ')' as value FROM core.shipping_package_shapes;";
			using (NpgsqlCommand command = new NpgsqlCommand(sql))
			{
				using (DataTable table = DbOperation.GetDataTable(this.Catalog, command))
				{
					if (table?.Rows == null || table.Rows.Count == 0)
					{
						return displayFields;
					}

					foreach (DataRow row in table.Rows)
					{
						if (row != null)
						{
							DisplayField displayField = new DisplayField
							{
								Key = row["key"].ToString(),
								Value = row["value"].ToString()
							};

							displayFields.Add(displayField);
						}
					}
				}
			}

			return displayFields;
		}

		/// <summary>
		/// Inserts the instance of ShippingPackageShape class on the database table "core.shipping_package_shapes".
		/// </summary>
		/// <param name="shippingPackageShape">The instance of "ShippingPackageShape" class to insert.</param>
		public void Add(MixERP.Net.Entities.Core.ShippingPackageShape shippingPackageShape)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Create, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to add entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}. {ShippingPackageShape}", this.LoginId, shippingPackageShape);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			Factory.Insert(this.Catalog, shippingPackageShape);
		}

		/// <summary>
		/// Updates the row of the table "core.shipping_package_shapes" with an instance of "ShippingPackageShape" class against the primary key value.
		/// </summary>
		/// <param name="shippingPackageShape">The instance of "ShippingPackageShape" class to update.</param>
		/// <param name="shippingPackageShapeId">The value of the column "shipping_package_shape_id" which will be updated.</param>
		public void Update(MixERP.Net.Entities.Core.ShippingPackageShape shippingPackageShape, int shippingPackageShapeId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Edit, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to edit entity \"ShippingPackageShape\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {ShippingPackageShape}", shippingPackageShapeId, this.LoginId, shippingPackageShape);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			Factory.Update(this.Catalog, shippingPackageShape, shippingPackageShapeId);
		}

		/// <summary>
		/// Deletes the row of the table "core.shipping_package_shapes" against the primary key value.
		/// </summary>
		/// <param name="shippingPackageShapeId">The value of the column "shipping_package_shape_id" which will be deleted.</param>
		public void Delete(int shippingPackageShapeId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Delete, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to delete entity \"ShippingPackageShape\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", shippingPackageShapeId, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "DELETE FROM core.shipping_package_shapes WHERE shipping_package_shape_id=@0;";
			Factory.NonQuery(this.Catalog, sql, shippingPackageShapeId);
		}

		/// <summary>
		/// Performs a select statement on table "core.shipping_package_shapes" producing a paged result of 25.
		/// </summary>
		/// <returns>Returns the first page of collection of "ShippingPackageShape" class.</returns>
		public IEnumerable<MixERP.Net.Entities.Core.ShippingPackageShape> GetPagedResult()
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the first page of the entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}.", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT * FROM core.shipping_package_shapes ORDER BY shipping_package_shape_id LIMIT 25 OFFSET 0;";
			return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this.Catalog, sql);
		}

		/// <summary>
		/// Performs a select statement on table "core.shipping_package_shapes" producing a paged result of 25.
		/// </summary>
		/// <param name="pageNumber">Enter the page number to produce the paged result.</param>
		/// <returns>Returns collection of "ShippingPackageShape" class.</returns>
		public IEnumerable<MixERP.Net.Entities.Core.ShippingPackageShape> GetPagedResult(long pageNumber)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}.", pageNumber, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			long offset = (pageNumber -1) * 25;
			const string sql = "SELECT * FROM core.shipping_package_shapes ORDER BY shipping_package_shape_id LIMIT 25 OFFSET @0;";
				
			return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this.Catalog, sql, offset);
		}
	}
}