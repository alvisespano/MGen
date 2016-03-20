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
	/// This class is the base class for any <see cref="PistoneProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PistoneProviderBaseCore : EntityProviderBase<GenTest.Entities.Pistone, GenTest.Entities.PistoneKey>
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
		public override bool Delete(TransactionManager transactionManager, GenTest.Entities.PistoneKey key)
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
		/// 	Gets rows from the datasource based on the FK_Composition_Pistone_Motore key.
		///		FK_Composition_Pistone_Motore Description: 
		/// </summary>
		/// <param name="_compositionMotoreID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByCompositionMotoreID(System.Int32? _compositionMotoreID)
		{
			int count = -1;
			return GetByCompositionMotoreID(_compositionMotoreID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composition_Pistone_Motore key.
		///		FK_Composition_Pistone_Motore Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_compositionMotoreID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		/// <remarks></remarks>
		public TList<Pistone> GetByCompositionMotoreID(TransactionManager transactionManager, System.Int32? _compositionMotoreID)
		{
			int count = -1;
			return GetByCompositionMotoreID(transactionManager, _compositionMotoreID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composition_Pistone_Motore key.
		///		FK_Composition_Pistone_Motore Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_compositionMotoreID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByCompositionMotoreID(TransactionManager transactionManager, System.Int32? _compositionMotoreID, int start, int pageLength)
		{
			int count = -1;
			return GetByCompositionMotoreID(transactionManager, _compositionMotoreID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composition_Pistone_Motore key.
		///		fKCompositionPistoneMotore Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_compositionMotoreID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByCompositionMotoreID(System.Int32? _compositionMotoreID, int start, int pageLength)
		{
			int count =  -1;
			return GetByCompositionMotoreID(null, _compositionMotoreID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composition_Pistone_Motore key.
		///		fKCompositionPistoneMotore Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_compositionMotoreID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByCompositionMotoreID(System.Int32? _compositionMotoreID, int start, int pageLength,out int count)
		{
			return GetByCompositionMotoreID(null, _compositionMotoreID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composition_Pistone_Motore key.
		///		FK_Composition_Pistone_Motore Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_compositionMotoreID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public abstract TList<Pistone> GetByCompositionMotoreID(TransactionManager transactionManager, System.Int32? _compositionMotoreID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TrakAggregation_Pistone_Pistone key.
		///		FK_TrakAggregation_Pistone_Pistone Description: 
		/// </summary>
		/// <param name="_trakAggregationPistoneID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByTrakAggregationPistoneID(System.Int32? _trakAggregationPistoneID)
		{
			int count = -1;
			return GetByTrakAggregationPistoneID(_trakAggregationPistoneID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TrakAggregation_Pistone_Pistone key.
		///		FK_TrakAggregation_Pistone_Pistone Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_trakAggregationPistoneID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		/// <remarks></remarks>
		public TList<Pistone> GetByTrakAggregationPistoneID(TransactionManager transactionManager, System.Int32? _trakAggregationPistoneID)
		{
			int count = -1;
			return GetByTrakAggregationPistoneID(transactionManager, _trakAggregationPistoneID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_TrakAggregation_Pistone_Pistone key.
		///		FK_TrakAggregation_Pistone_Pistone Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_trakAggregationPistoneID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByTrakAggregationPistoneID(TransactionManager transactionManager, System.Int32? _trakAggregationPistoneID, int start, int pageLength)
		{
			int count = -1;
			return GetByTrakAggregationPistoneID(transactionManager, _trakAggregationPistoneID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TrakAggregation_Pistone_Pistone key.
		///		fKTrakAggregationPistonePistone Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_trakAggregationPistoneID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByTrakAggregationPistoneID(System.Int32? _trakAggregationPistoneID, int start, int pageLength)
		{
			int count =  -1;
			return GetByTrakAggregationPistoneID(null, _trakAggregationPistoneID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TrakAggregation_Pistone_Pistone key.
		///		fKTrakAggregationPistonePistone Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_trakAggregationPistoneID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByTrakAggregationPistoneID(System.Int32? _trakAggregationPistoneID, int start, int pageLength,out int count)
		{
			return GetByTrakAggregationPistoneID(null, _trakAggregationPistoneID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TrakAggregation_Pistone_Pistone key.
		///		FK_TrakAggregation_Pistone_Pistone Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_trakAggregationPistoneID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public abstract TList<Pistone> GetByTrakAggregationPistoneID(TransactionManager transactionManager, System.Int32? _trakAggregationPistoneID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Pistone_Pistone key.
		///		FK_Aggregation_Pistone_Pistone Description: 
		/// </summary>
		/// <param name="_aggregationPistoneID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByAggregationPistoneID(System.Int32? _aggregationPistoneID)
		{
			int count = -1;
			return GetByAggregationPistoneID(_aggregationPistoneID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Pistone_Pistone key.
		///		FK_Aggregation_Pistone_Pistone Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationPistoneID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		/// <remarks></remarks>
		public TList<Pistone> GetByAggregationPistoneID(TransactionManager transactionManager, System.Int32? _aggregationPistoneID)
		{
			int count = -1;
			return GetByAggregationPistoneID(transactionManager, _aggregationPistoneID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Pistone_Pistone key.
		///		FK_Aggregation_Pistone_Pistone Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationPistoneID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByAggregationPistoneID(TransactionManager transactionManager, System.Int32? _aggregationPistoneID, int start, int pageLength)
		{
			int count = -1;
			return GetByAggregationPistoneID(transactionManager, _aggregationPistoneID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Pistone_Pistone key.
		///		fKAggregationPistonePistone Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_aggregationPistoneID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByAggregationPistoneID(System.Int32? _aggregationPistoneID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAggregationPistoneID(null, _aggregationPistoneID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Pistone_Pistone key.
		///		fKAggregationPistonePistone Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_aggregationPistoneID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public TList<Pistone> GetByAggregationPistoneID(System.Int32? _aggregationPistoneID, int start, int pageLength,out int count)
		{
			return GetByAggregationPistoneID(null, _aggregationPistoneID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Pistone_Pistone key.
		///		FK_Aggregation_Pistone_Pistone Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationPistoneID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.Pistone objects.</returns>
		public abstract TList<Pistone> GetByAggregationPistoneID(TransactionManager transactionManager, System.Int32? _aggregationPistoneID, int start, int pageLength, out int count);
		
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
		public override GenTest.Entities.Pistone Get(TransactionManager transactionManager, GenTest.Entities.PistoneKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Pistone index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Pistone"/> class.</returns>
		public GenTest.Entities.Pistone GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Pistone index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Pistone"/> class.</returns>
		public GenTest.Entities.Pistone GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Pistone index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Pistone"/> class.</returns>
		public GenTest.Entities.Pistone GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Pistone index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Pistone"/> class.</returns>
		public GenTest.Entities.Pistone GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Pistone index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Pistone"/> class.</returns>
		public GenTest.Entities.Pistone GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Pistone index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Pistone"/> class.</returns>
		public abstract GenTest.Entities.Pistone GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Pistone&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Pistone&gt;"/></returns>
		public static TList<Pistone> Fill(IDataReader reader, TList<Pistone> rows, int start, int pageLength)
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
				
				GenTest.Entities.Pistone c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Pistone")
					.Append("|").Append((reader.IsDBNull(((int)GenTest.Entities.PistoneColumn.ID - 1))?(int)0:(System.Int32)reader[((int)GenTest.Entities.PistoneColumn.ID - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Pistone>(
					key.ToString(), // EntityTrackingKey
					"Pistone",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new GenTest.Entities.Pistone();
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
					c.Temperatura = (System.Double)reader[((int)PistoneColumn.Temperatura - 1)];
					c.ID = (System.Int32)reader[((int)PistoneColumn.ID - 1)];
					c.CompositionMotoreID = (reader.IsDBNull(((int)PistoneColumn.CompositionMotoreID - 1)))?null:(System.Int32?)reader[((int)PistoneColumn.CompositionMotoreID - 1)];
					c.TrakAggregationPistoneID = (reader.IsDBNull(((int)PistoneColumn.TrakAggregationPistoneID - 1)))?null:(System.Int32?)reader[((int)PistoneColumn.TrakAggregationPistoneID - 1)];
					c.AggregationPistoneID = (reader.IsDBNull(((int)PistoneColumn.AggregationPistoneID - 1)))?null:(System.Int32?)reader[((int)PistoneColumn.AggregationPistoneID - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Pistone"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Pistone"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, GenTest.Entities.Pistone entity)
		{
			if (!reader.Read()) return;
			
			entity.Temperatura = (System.Double)reader[((int)PistoneColumn.Temperatura - 1)];
			entity.ID = (System.Int32)reader[((int)PistoneColumn.ID - 1)];
			entity.CompositionMotoreID = (reader.IsDBNull(((int)PistoneColumn.CompositionMotoreID - 1)))?null:(System.Int32?)reader[((int)PistoneColumn.CompositionMotoreID - 1)];
			entity.TrakAggregationPistoneID = (reader.IsDBNull(((int)PistoneColumn.TrakAggregationPistoneID - 1)))?null:(System.Int32?)reader[((int)PistoneColumn.TrakAggregationPistoneID - 1)];
			entity.AggregationPistoneID = (reader.IsDBNull(((int)PistoneColumn.AggregationPistoneID - 1)))?null:(System.Int32?)reader[((int)PistoneColumn.AggregationPistoneID - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Pistone"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Pistone"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, GenTest.Entities.Pistone entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Temperatura = (System.Double)dataRow["Temperatura"];
			entity.ID = (System.Int32)dataRow["ID"];
			entity.CompositionMotoreID = Convert.IsDBNull(dataRow["CompositionMotoreID"]) ? null : (System.Int32?)dataRow["CompositionMotoreID"];
			entity.TrakAggregationPistoneID = Convert.IsDBNull(dataRow["TrakAggregationPistoneID"]) ? null : (System.Int32?)dataRow["TrakAggregationPistoneID"];
			entity.AggregationPistoneID = Convert.IsDBNull(dataRow["AggregationPistoneID"]) ? null : (System.Int32?)dataRow["AggregationPistoneID"];
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
		/// <param name="entity">The <see cref="GenTest.Entities.Pistone"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">GenTest.Entities.Pistone Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, GenTest.Entities.Pistone entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CompositionMotoreIDSource	
			if (CanDeepLoad(entity, "Motore|CompositionMotoreIDSource", deepLoadType, innerList) 
				&& entity.CompositionMotoreIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CompositionMotoreID ?? (int)0);
				Motore tmpEntity = EntityManager.LocateEntity<Motore>(EntityLocator.ConstructKeyFromPkItems(typeof(Motore), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CompositionMotoreIDSource = tmpEntity;
				else
					entity.CompositionMotoreIDSource = DataRepository.MotoreProvider.GetByID(transactionManager, (entity.CompositionMotoreID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompositionMotoreIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CompositionMotoreIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MotoreProvider.DeepLoad(transactionManager, entity.CompositionMotoreIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CompositionMotoreIDSource

			#region TrakAggregationPistoneIDSource	
			if (CanDeepLoad(entity, "Pistone|TrakAggregationPistoneIDSource", deepLoadType, innerList) 
				&& entity.TrakAggregationPistoneIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.TrakAggregationPistoneID ?? (int)0);
				Pistone tmpEntity = EntityManager.LocateEntity<Pistone>(EntityLocator.ConstructKeyFromPkItems(typeof(Pistone), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TrakAggregationPistoneIDSource = tmpEntity;
				else
					entity.TrakAggregationPistoneIDSource = DataRepository.PistoneProvider.GetByID(transactionManager, (entity.TrakAggregationPistoneID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TrakAggregationPistoneIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TrakAggregationPistoneIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PistoneProvider.DeepLoad(transactionManager, entity.TrakAggregationPistoneIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TrakAggregationPistoneIDSource

			#region AggregationPistoneIDSource	
			if (CanDeepLoad(entity, "Pistone|AggregationPistoneIDSource", deepLoadType, innerList) 
				&& entity.AggregationPistoneIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AggregationPistoneID ?? (int)0);
				Pistone tmpEntity = EntityManager.LocateEntity<Pistone>(EntityLocator.ConstructKeyFromPkItems(typeof(Pistone), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AggregationPistoneIDSource = tmpEntity;
				else
					entity.AggregationPistoneIDSource = DataRepository.PistoneProvider.GetByID(transactionManager, (entity.AggregationPistoneID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AggregationPistoneIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AggregationPistoneIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PistoneProvider.DeepLoad(transactionManager, entity.AggregationPistoneIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AggregationPistoneIDSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region PistoneCollectionGetByAggregationPistoneID
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Pistone>|PistoneCollectionGetByAggregationPistoneID", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PistoneCollectionGetByAggregationPistoneID' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PistoneCollectionGetByAggregationPistoneID = DataRepository.PistoneProvider.GetByAggregationPistoneID(transactionManager, entity.ID);

				if (deep && entity.PistoneCollectionGetByAggregationPistoneID.Count > 0)
				{
					deepHandles.Add("PistoneCollectionGetByAggregationPistoneID",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Pistone>) DataRepository.PistoneProvider.DeepLoad,
						new object[] { transactionManager, entity.PistoneCollectionGetByAggregationPistoneID, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region PistoneCollectionGetByTrakAggregationPistoneID
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Pistone>|PistoneCollectionGetByTrakAggregationPistoneID", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PistoneCollectionGetByTrakAggregationPistoneID' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PistoneCollectionGetByTrakAggregationPistoneID = DataRepository.PistoneProvider.GetByTrakAggregationPistoneID(transactionManager, entity.ID);

				if (deep && entity.PistoneCollectionGetByTrakAggregationPistoneID.Count > 0)
				{
					deepHandles.Add("PistoneCollectionGetByTrakAggregationPistoneID",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Pistone>) DataRepository.PistoneProvider.DeepLoad,
						new object[] { transactionManager, entity.PistoneCollectionGetByTrakAggregationPistoneID, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the GenTest.Entities.Pistone object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">GenTest.Entities.Pistone instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">GenTest.Entities.Pistone Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, GenTest.Entities.Pistone entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CompositionMotoreIDSource
			if (CanDeepSave(entity, "Motore|CompositionMotoreIDSource", deepSaveType, innerList) 
				&& entity.CompositionMotoreIDSource != null)
			{
				DataRepository.MotoreProvider.Save(transactionManager, entity.CompositionMotoreIDSource);
				entity.CompositionMotoreID = entity.CompositionMotoreIDSource.ID;
			}
			#endregion 
			
			#region TrakAggregationPistoneIDSource
			if (CanDeepSave(entity, "Pistone|TrakAggregationPistoneIDSource", deepSaveType, innerList) 
				&& entity.TrakAggregationPistoneIDSource != null)
			{
				DataRepository.PistoneProvider.Save(transactionManager, entity.TrakAggregationPistoneIDSource);
				entity.TrakAggregationPistoneID = entity.TrakAggregationPistoneIDSource.ID;
			}
			#endregion 
			
			#region AggregationPistoneIDSource
			if (CanDeepSave(entity, "Pistone|AggregationPistoneIDSource", deepSaveType, innerList) 
				&& entity.AggregationPistoneIDSource != null)
			{
				DataRepository.PistoneProvider.Save(transactionManager, entity.AggregationPistoneIDSource);
				entity.AggregationPistoneID = entity.AggregationPistoneIDSource.ID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Pistone>
				if (CanDeepSave(entity.PistoneCollectionGetByAggregationPistoneID, "List<Pistone>|PistoneCollectionGetByAggregationPistoneID", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Pistone child in entity.PistoneCollectionGetByAggregationPistoneID)
					{
						if(child.AggregationPistoneIDSource != null)
						{
							child.AggregationPistoneID = child.AggregationPistoneIDSource.ID;
						}
						else
						{
							child.AggregationPistoneID = entity.ID;
						}

					}

					if (entity.PistoneCollectionGetByAggregationPistoneID.Count > 0 || entity.PistoneCollectionGetByAggregationPistoneID.DeletedItems.Count > 0)
					{
						//DataRepository.PistoneProvider.Save(transactionManager, entity.PistoneCollectionGetByAggregationPistoneID);
						
						deepHandles.Add("PistoneCollectionGetByAggregationPistoneID",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Pistone >) DataRepository.PistoneProvider.DeepSave,
							new object[] { transactionManager, entity.PistoneCollectionGetByAggregationPistoneID, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Pistone>
				if (CanDeepSave(entity.PistoneCollectionGetByTrakAggregationPistoneID, "List<Pistone>|PistoneCollectionGetByTrakAggregationPistoneID", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Pistone child in entity.PistoneCollectionGetByTrakAggregationPistoneID)
					{
						if(child.TrakAggregationPistoneIDSource != null)
						{
							child.TrakAggregationPistoneID = child.TrakAggregationPistoneIDSource.ID;
						}
						else
						{
							child.TrakAggregationPistoneID = entity.ID;
						}

					}

					if (entity.PistoneCollectionGetByTrakAggregationPistoneID.Count > 0 || entity.PistoneCollectionGetByTrakAggregationPistoneID.DeletedItems.Count > 0)
					{
						//DataRepository.PistoneProvider.Save(transactionManager, entity.PistoneCollectionGetByTrakAggregationPistoneID);
						
						deepHandles.Add("PistoneCollectionGetByTrakAggregationPistoneID",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Pistone >) DataRepository.PistoneProvider.DeepSave,
							new object[] { transactionManager, entity.PistoneCollectionGetByTrakAggregationPistoneID, deepSaveType, childTypes, innerList }
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
	
	#region PistoneChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>GenTest.Entities.Pistone</c>
	///</summary>
	public enum PistoneChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Motore</c> at CompositionMotoreIDSource
		///</summary>
		[ChildEntityType(typeof(Motore))]
		Motore,
			
		///<summary>
		/// Composite Property for <c>Pistone</c> at TrakAggregationPistoneIDSource
		///</summary>
		[ChildEntityType(typeof(Pistone))]
		Pistone,
	
		///<summary>
		/// Collection of <c>Pistone</c> as OneToMany for PistoneCollection
		///</summary>
		[ChildEntityType(typeof(TList<Pistone>))]
		PistoneCollectionGetByAggregationPistoneID,

		///<summary>
		/// Collection of <c>Pistone</c> as OneToMany for PistoneCollection
		///</summary>
		[ChildEntityType(typeof(TList<Pistone>))]
		PistoneCollectionGetByTrakAggregationPistoneID,
	}
	
	#endregion PistoneChildEntityTypes
	
	#region PistoneFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PistoneColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Pistone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PistoneFilterBuilder : SqlFilterBuilder<PistoneColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PistoneFilterBuilder class.
		/// </summary>
		public PistoneFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PistoneFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PistoneFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PistoneFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PistoneFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PistoneFilterBuilder
	
	#region PistoneParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PistoneColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Pistone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PistoneParameterBuilder : ParameterizedSqlFilterBuilder<PistoneColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PistoneParameterBuilder class.
		/// </summary>
		public PistoneParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PistoneParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PistoneParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PistoneParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PistoneParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PistoneParameterBuilder
} // end namespace
