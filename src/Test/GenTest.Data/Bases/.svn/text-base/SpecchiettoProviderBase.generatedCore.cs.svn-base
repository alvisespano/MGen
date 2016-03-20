#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using GenTest.Entities;
using GenTest.Data;

#endregion

namespace GenTest.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="SpecchiettoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SpecchiettoProviderBaseCore : EntityProviderBase<GenTest.Entities.Specchietto, GenTest.Entities.SpecchiettoKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, GenTest.Entities.SpecchiettoKey key)
		{
			return Delete(transactionManager, key.ID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_iD">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _iD)
		{
			return Delete(null, _iD);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _iD);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Specchietto_Macchina key.
		///		FK_Aggregation_Specchietto_Macchina Description: 
		/// </summary>
		/// <param name="_aggregationMacchinaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Specchietto objects.</returns>
		public TList<Specchietto> GetByAggregationMacchinaID(System.Int32? _aggregationMacchinaID)
		{
			int count = -1;
			return GetByAggregationMacchinaID(_aggregationMacchinaID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Specchietto_Macchina key.
		///		FK_Aggregation_Specchietto_Macchina Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationMacchinaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Specchietto objects.</returns>
		/// <remarks></remarks>
		public TList<Specchietto> GetByAggregationMacchinaID(TransactionManager transactionManager, System.Int32? _aggregationMacchinaID)
		{
			int count = -1;
			return GetByAggregationMacchinaID(transactionManager, _aggregationMacchinaID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Specchietto_Macchina key.
		///		FK_Aggregation_Specchietto_Macchina Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationMacchinaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Specchietto objects.</returns>
		public TList<Specchietto> GetByAggregationMacchinaID(TransactionManager transactionManager, System.Int32? _aggregationMacchinaID, int start, int pageLength)
		{
			int count = -1;
			return GetByAggregationMacchinaID(transactionManager, _aggregationMacchinaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Specchietto_Macchina key.
		///		fKAggregationSpecchiettoMacchina Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_aggregationMacchinaID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Specchietto objects.</returns>
		public TList<Specchietto> GetByAggregationMacchinaID(System.Int32? _aggregationMacchinaID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAggregationMacchinaID(null, _aggregationMacchinaID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Specchietto_Macchina key.
		///		fKAggregationSpecchiettoMacchina Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_aggregationMacchinaID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Specchietto objects.</returns>
		public TList<Specchietto> GetByAggregationMacchinaID(System.Int32? _aggregationMacchinaID, int start, int pageLength,out int count)
		{
			return GetByAggregationMacchinaID(null, _aggregationMacchinaID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Specchietto_Macchina key.
		///		FK_Aggregation_Specchietto_Macchina Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationMacchinaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.Specchietto objects.</returns>
		public abstract TList<Specchietto> GetByAggregationMacchinaID(TransactionManager transactionManager, System.Int32? _aggregationMacchinaID, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override GenTest.Entities.Specchietto Get(TransactionManager transactionManager, GenTest.Entities.SpecchiettoKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Specchietto index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Specchietto index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Specchietto index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Specchietto index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Specchietto index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Specchietto index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public abstract GenTest.Entities.Specchietto GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UQ__Specchietto__173876EA index.
		/// </summary>
		/// <param name="_associationSpecchiettoID"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByAssociationSpecchiettoID(System.Int32? _associationSpecchiettoID)
		{
			int count = -1;
			return GetByAssociationSpecchiettoID(null,_associationSpecchiettoID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__173876EA index.
		/// </summary>
		/// <param name="_associationSpecchiettoID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByAssociationSpecchiettoID(System.Int32? _associationSpecchiettoID, int start, int pageLength)
		{
			int count = -1;
			return GetByAssociationSpecchiettoID(null, _associationSpecchiettoID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_associationSpecchiettoID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByAssociationSpecchiettoID(TransactionManager transactionManager, System.Int32? _associationSpecchiettoID)
		{
			int count = -1;
			return GetByAssociationSpecchiettoID(transactionManager, _associationSpecchiettoID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_associationSpecchiettoID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByAssociationSpecchiettoID(TransactionManager transactionManager, System.Int32? _associationSpecchiettoID, int start, int pageLength)
		{
			int count = -1;
			return GetByAssociationSpecchiettoID(transactionManager, _associationSpecchiettoID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__173876EA index.
		/// </summary>
		/// <param name="_associationSpecchiettoID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetByAssociationSpecchiettoID(System.Int32? _associationSpecchiettoID, int start, int pageLength, out int count)
		{
			return GetByAssociationSpecchiettoID(null, _associationSpecchiettoID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_associationSpecchiettoID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public abstract GenTest.Entities.Specchietto GetByAssociationSpecchiettoID(TransactionManager transactionManager, System.Int32? _associationSpecchiettoID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UQ__Specchietto__182C9B23 index.
		/// </summary>
		/// <param name="_sgutAssociationSpecchiettoID"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetBySgutAssociationSpecchiettoID(System.Int32? _sgutAssociationSpecchiettoID)
		{
			int count = -1;
			return GetBySgutAssociationSpecchiettoID(null,_sgutAssociationSpecchiettoID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__182C9B23 index.
		/// </summary>
		/// <param name="_sgutAssociationSpecchiettoID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetBySgutAssociationSpecchiettoID(System.Int32? _sgutAssociationSpecchiettoID, int start, int pageLength)
		{
			int count = -1;
			return GetBySgutAssociationSpecchiettoID(null, _sgutAssociationSpecchiettoID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__182C9B23 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sgutAssociationSpecchiettoID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetBySgutAssociationSpecchiettoID(TransactionManager transactionManager, System.Int32? _sgutAssociationSpecchiettoID)
		{
			int count = -1;
			return GetBySgutAssociationSpecchiettoID(transactionManager, _sgutAssociationSpecchiettoID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__182C9B23 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sgutAssociationSpecchiettoID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetBySgutAssociationSpecchiettoID(TransactionManager transactionManager, System.Int32? _sgutAssociationSpecchiettoID, int start, int pageLength)
		{
			int count = -1;
			return GetBySgutAssociationSpecchiettoID(transactionManager, _sgutAssociationSpecchiettoID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__182C9B23 index.
		/// </summary>
		/// <param name="_sgutAssociationSpecchiettoID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public GenTest.Entities.Specchietto GetBySgutAssociationSpecchiettoID(System.Int32? _sgutAssociationSpecchiettoID, int start, int pageLength, out int count)
		{
			return GetBySgutAssociationSpecchiettoID(null, _sgutAssociationSpecchiettoID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Specchietto__182C9B23 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sgutAssociationSpecchiettoID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Specchietto"/> class.</returns>
		public abstract GenTest.Entities.Specchietto GetBySgutAssociationSpecchiettoID(TransactionManager transactionManager, System.Int32? _sgutAssociationSpecchiettoID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Specchietto&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Specchietto&gt;"/></returns>
		public static TList<Specchietto> Fill(IDataReader reader, TList<Specchietto> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				GenTest.Entities.Specchietto c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Specchietto")
					.Append("|").Append((reader.IsDBNull(((int)GenTest.Entities.SpecchiettoColumn.ID - 1))?(int)0:(System.Int32)reader[((int)GenTest.Entities.SpecchiettoColumn.ID - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Specchietto>(
					key.ToString(), // EntityTrackingKey
					"Specchietto",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new GenTest.Entities.Specchietto();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged || c.EntityState == EntityState.Changed))
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.Larghezza = (System.Double)reader[((int)SpecchiettoColumn.Larghezza - 1)];
					c.ID = (System.Int32)reader[((int)SpecchiettoColumn.ID - 1)];
					c.AggregationMacchinaID = (reader.IsDBNull(((int)SpecchiettoColumn.AggregationMacchinaID - 1)))?null:(System.Int32?)reader[((int)SpecchiettoColumn.AggregationMacchinaID - 1)];
					c.SgutAssociationSpecchiettoID = (reader.IsDBNull(((int)SpecchiettoColumn.SgutAssociationSpecchiettoID - 1)))?null:(System.Int32?)reader[((int)SpecchiettoColumn.SgutAssociationSpecchiettoID - 1)];
					c.AssociationSpecchiettoID = (reader.IsDBNull(((int)SpecchiettoColumn.AssociationSpecchiettoID - 1)))?null:(System.Int32?)reader[((int)SpecchiettoColumn.AssociationSpecchiettoID - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Specchietto"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Specchietto"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, GenTest.Entities.Specchietto entity)
		{
			if (!reader.Read()) return;
			
			entity.Larghezza = (System.Double)reader[((int)SpecchiettoColumn.Larghezza - 1)];
			entity.ID = (System.Int32)reader[((int)SpecchiettoColumn.ID - 1)];
			entity.AggregationMacchinaID = (reader.IsDBNull(((int)SpecchiettoColumn.AggregationMacchinaID - 1)))?null:(System.Int32?)reader[((int)SpecchiettoColumn.AggregationMacchinaID - 1)];
			entity.SgutAssociationSpecchiettoID = (reader.IsDBNull(((int)SpecchiettoColumn.SgutAssociationSpecchiettoID - 1)))?null:(System.Int32?)reader[((int)SpecchiettoColumn.SgutAssociationSpecchiettoID - 1)];
			entity.AssociationSpecchiettoID = (reader.IsDBNull(((int)SpecchiettoColumn.AssociationSpecchiettoID - 1)))?null:(System.Int32?)reader[((int)SpecchiettoColumn.AssociationSpecchiettoID - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Specchietto"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Specchietto"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, GenTest.Entities.Specchietto entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Larghezza = (System.Double)dataRow["Larghezza"];
			entity.ID = (System.Int32)dataRow["ID"];
			entity.AggregationMacchinaID = Convert.IsDBNull(dataRow["AggregationMacchinaID"]) ? null : (System.Int32?)dataRow["AggregationMacchinaID"];
			entity.SgutAssociationSpecchiettoID = Convert.IsDBNull(dataRow["SgutAssociationSpecchiettoID"]) ? null : (System.Int32?)dataRow["SgutAssociationSpecchiettoID"];
			entity.AssociationSpecchiettoID = Convert.IsDBNull(dataRow["AssociationSpecchiettoID"]) ? null : (System.Int32?)dataRow["AssociationSpecchiettoID"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Specchietto"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">GenTest.Entities.Specchietto Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, GenTest.Entities.Specchietto entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AggregationMacchinaIDSource	
			if (CanDeepLoad(entity, "Macchina|AggregationMacchinaIDSource", deepLoadType, innerList) 
				&& entity.AggregationMacchinaIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AggregationMacchinaID ?? (int)0);
				Macchina tmpEntity = EntityManager.LocateEntity<Macchina>(EntityLocator.ConstructKeyFromPkItems(typeof(Macchina), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AggregationMacchinaIDSource = tmpEntity;
				else
					entity.AggregationMacchinaIDSource = DataRepository.MacchinaProvider.GetByID(transactionManager, (entity.AggregationMacchinaID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AggregationMacchinaIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AggregationMacchinaIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MacchinaProvider.DeepLoad(transactionManager, entity.AggregationMacchinaIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AggregationMacchinaIDSource

			#region SgutAssociationSpecchiettoIDSource	
			if (CanDeepLoad(entity, "Specchietto|SgutAssociationSpecchiettoIDSource", deepLoadType, innerList) 
				&& entity.SgutAssociationSpecchiettoIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SgutAssociationSpecchiettoID ?? (int)0);
				Specchietto tmpEntity = EntityManager.LocateEntity<Specchietto>(EntityLocator.ConstructKeyFromPkItems(typeof(Specchietto), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SgutAssociationSpecchiettoIDSource = tmpEntity;
				else
					entity.SgutAssociationSpecchiettoIDSource = DataRepository.SpecchiettoProvider.GetByID(transactionManager, (entity.SgutAssociationSpecchiettoID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SgutAssociationSpecchiettoIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SgutAssociationSpecchiettoIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SpecchiettoProvider.DeepLoad(transactionManager, entity.SgutAssociationSpecchiettoIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SgutAssociationSpecchiettoIDSource

			#region AssociationSpecchiettoIDSource	
			if (CanDeepLoad(entity, "Specchietto|AssociationSpecchiettoIDSource", deepLoadType, innerList) 
				&& entity.AssociationSpecchiettoIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AssociationSpecchiettoID ?? (int)0);
				Specchietto tmpEntity = EntityManager.LocateEntity<Specchietto>(EntityLocator.ConstructKeyFromPkItems(typeof(Specchietto), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AssociationSpecchiettoIDSource = tmpEntity;
				else
					entity.AssociationSpecchiettoIDSource = DataRepository.SpecchiettoProvider.GetByID(transactionManager, (entity.AssociationSpecchiettoID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AssociationSpecchiettoIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AssociationSpecchiettoIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SpecchiettoProvider.DeepLoad(transactionManager, entity.AssociationSpecchiettoIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AssociationSpecchiettoIDSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region SpecchiettoGetBySgutAssociationSpecchiettoID
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "Specchietto|SpecchiettoGetBySgutAssociationSpecchiettoID", deepLoadType, innerList))
			{
				entity.SpecchiettoGetBySgutAssociationSpecchiettoID = DataRepository.SpecchiettoProvider.GetBySgutAssociationSpecchiettoID(transactionManager, entity.ID);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SpecchiettoGetBySgutAssociationSpecchiettoID' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.SpecchiettoGetBySgutAssociationSpecchiettoID != null)
				{
					deepHandles.Add("SpecchiettoGetBySgutAssociationSpecchiettoID",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< Specchietto >) DataRepository.SpecchiettoProvider.DeepLoad,
						new object[] { transactionManager, entity.SpecchiettoGetBySgutAssociationSpecchiettoID, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region SpecchiettoGetByAssociationSpecchiettoID
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "Specchietto|SpecchiettoGetByAssociationSpecchiettoID", deepLoadType, innerList))
			{
				entity.SpecchiettoGetByAssociationSpecchiettoID = DataRepository.SpecchiettoProvider.GetByAssociationSpecchiettoID(transactionManager, entity.ID);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SpecchiettoGetByAssociationSpecchiettoID' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.SpecchiettoGetByAssociationSpecchiettoID != null)
				{
					deepHandles.Add("SpecchiettoGetByAssociationSpecchiettoID",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< Specchietto >) DataRepository.SpecchiettoProvider.DeepLoad,
						new object[] { transactionManager, entity.SpecchiettoGetByAssociationSpecchiettoID, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the GenTest.Entities.Specchietto object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">GenTest.Entities.Specchietto instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">GenTest.Entities.Specchietto Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, GenTest.Entities.Specchietto entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AggregationMacchinaIDSource
			if (CanDeepSave(entity, "Macchina|AggregationMacchinaIDSource", deepSaveType, innerList) 
				&& entity.AggregationMacchinaIDSource != null)
			{
				DataRepository.MacchinaProvider.Save(transactionManager, entity.AggregationMacchinaIDSource);
				entity.AggregationMacchinaID = entity.AggregationMacchinaIDSource.ID;
			}
			#endregion 
			
			#region SgutAssociationSpecchiettoIDSource
			if (CanDeepSave(entity, "Specchietto|SgutAssociationSpecchiettoIDSource", deepSaveType, innerList) 
				&& entity.SgutAssociationSpecchiettoIDSource != null)
			{
				DataRepository.SpecchiettoProvider.Save(transactionManager, entity.SgutAssociationSpecchiettoIDSource);
				entity.SgutAssociationSpecchiettoID = entity.SgutAssociationSpecchiettoIDSource.ID;
			}
			#endregion 
			
			#region AssociationSpecchiettoIDSource
			if (CanDeepSave(entity, "Specchietto|AssociationSpecchiettoIDSource", deepSaveType, innerList) 
				&& entity.AssociationSpecchiettoIDSource != null)
			{
				DataRepository.SpecchiettoProvider.Save(transactionManager, entity.AssociationSpecchiettoIDSource);
				entity.AssociationSpecchiettoID = entity.AssociationSpecchiettoIDSource.ID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region SpecchiettoGetBySgutAssociationSpecchiettoID
			if (CanDeepSave(entity.SpecchiettoGetBySgutAssociationSpecchiettoID, "Specchietto|SpecchiettoGetBySgutAssociationSpecchiettoID", deepSaveType, innerList))
			{

				if (entity.SpecchiettoGetBySgutAssociationSpecchiettoID != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.Specchietto.SgutAssociationSpecchiettoID = entity.ID;
					//DataRepository.SpecchiettoProvider.Save(transactionManager, entity.SpecchiettoGetBySgutAssociationSpecchiettoID);
					deepHandles.Add("SpecchiettoGetBySgutAssociationSpecchiettoID",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< Specchietto >) DataRepository.SpecchiettoProvider.DeepSave,
						new object[] { transactionManager, entity.SpecchiettoGetBySgutAssociationSpecchiettoID, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 

			#region SpecchiettoGetByAssociationSpecchiettoID
			if (CanDeepSave(entity.SpecchiettoGetByAssociationSpecchiettoID, "Specchietto|SpecchiettoGetByAssociationSpecchiettoID", deepSaveType, innerList))
			{

				if (entity.SpecchiettoGetByAssociationSpecchiettoID != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.Specchietto.AssociationSpecchiettoID = entity.ID;
					//DataRepository.SpecchiettoProvider.Save(transactionManager, entity.SpecchiettoGetByAssociationSpecchiettoID);
					deepHandles.Add("SpecchiettoGetByAssociationSpecchiettoID",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< Specchietto >) DataRepository.SpecchiettoProvider.DeepSave,
						new object[] { transactionManager, entity.SpecchiettoGetByAssociationSpecchiettoID, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region SpecchiettoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>GenTest.Entities.Specchietto</c>
	///</summary>
	public enum SpecchiettoChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Macchina</c> at AggregationMacchinaIDSource
		///</summary>
		[ChildEntityType(typeof(Macchina))]
		Macchina,
			
		///<summary>
		/// Composite Property for <c>Specchietto</c> at SgutAssociationSpecchiettoIDSource
		///</summary>
		[ChildEntityType(typeof(Specchietto))]
		Specchietto,
		}
	
	#endregion SpecchiettoChildEntityTypes
	
	#region SpecchiettoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SpecchiettoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Specchietto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecchiettoFilterBuilder : SqlFilterBuilder<SpecchiettoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecchiettoFilterBuilder class.
		/// </summary>
		public SpecchiettoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecchiettoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecchiettoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecchiettoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecchiettoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecchiettoFilterBuilder
	
	#region SpecchiettoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SpecchiettoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Specchietto"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SpecchiettoParameterBuilder : ParameterizedSqlFilterBuilder<SpecchiettoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SpecchiettoParameterBuilder class.
		/// </summary>
		public SpecchiettoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SpecchiettoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SpecchiettoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SpecchiettoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SpecchiettoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SpecchiettoParameterBuilder
} // end namespace
