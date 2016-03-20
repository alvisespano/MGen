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
	/// This class is the base class for any <see cref="RigaFatturaProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RigaFatturaProviderBaseCore : EntityProviderBase<GenTest.Entities.RigaFattura, GenTest.Entities.RigaFatturaKey>
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
		public override bool Delete(TransactionManager transactionManager, GenTest.Entities.RigaFatturaKey key)
		{
			return Delete(transactionManager, key.ID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="iD">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 iD)
		{
			return Delete(null, iD);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iD">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 iD);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_RigaFattura_Fattura key.
		///		FK_Composed_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="composedFatturaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public GenTest.Entities.TList<RigaFattura> GetByComposedFatturaID(System.Int32? composedFatturaID)
		{
			int count = -1;
			return GetByComposedFatturaID(composedFatturaID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_RigaFattura_Fattura key.
		///		FK_Composed_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="composedFatturaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		/// <remarks></remarks>
		public GenTest.Entities.TList<RigaFattura> GetByComposedFatturaID(TransactionManager transactionManager, System.Int32? composedFatturaID)
		{
			int count = -1;
			return GetByComposedFatturaID(transactionManager, composedFatturaID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_RigaFattura_Fattura key.
		///		FK_Composed_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="composedFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public GenTest.Entities.TList<RigaFattura> GetByComposedFatturaID(TransactionManager transactionManager, System.Int32? composedFatturaID, int start, int pageLength)
		{
			int count = -1;
			return GetByComposedFatturaID(transactionManager, composedFatturaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_RigaFattura_Fattura key.
		///		fK_Composed_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="composedFatturaID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public GenTest.Entities.TList<RigaFattura> GetByComposedFatturaID(System.Int32? composedFatturaID, int start, int pageLength)
		{
			int count =  -1;
			return GetByComposedFatturaID(null, composedFatturaID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_RigaFattura_Fattura key.
		///		fK_Composed_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="composedFatturaID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public GenTest.Entities.TList<RigaFattura> GetByComposedFatturaID(System.Int32? composedFatturaID, int start, int pageLength,out int count)
		{
			return GetByComposedFatturaID(null, composedFatturaID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_RigaFattura_Fattura key.
		///		FK_Composed_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="composedFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public abstract GenTest.Entities.TList<RigaFattura> GetByComposedFatturaID(TransactionManager transactionManager, System.Int32? composedFatturaID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_RigaFattura_Fattura key.
		///		FK_Aggregated_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="aggregatedFatturaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public GenTest.Entities.TList<RigaFattura> GetByAggregatedFatturaID(System.Int32? aggregatedFatturaID)
		{
			int count = -1;
			return GetByAggregatedFatturaID(aggregatedFatturaID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_RigaFattura_Fattura key.
		///		FK_Aggregated_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="aggregatedFatturaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		/// <remarks></remarks>
		public GenTest.Entities.TList<RigaFattura> GetByAggregatedFatturaID(TransactionManager transactionManager, System.Int32? aggregatedFatturaID)
		{
			int count = -1;
			return GetByAggregatedFatturaID(transactionManager, aggregatedFatturaID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_RigaFattura_Fattura key.
		///		FK_Aggregated_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="aggregatedFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public GenTest.Entities.TList<RigaFattura> GetByAggregatedFatturaID(TransactionManager transactionManager, System.Int32? aggregatedFatturaID, int start, int pageLength)
		{
			int count = -1;
			return GetByAggregatedFatturaID(transactionManager, aggregatedFatturaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_RigaFattura_Fattura key.
		///		fK_Aggregated_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="aggregatedFatturaID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public GenTest.Entities.TList<RigaFattura> GetByAggregatedFatturaID(System.Int32? aggregatedFatturaID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAggregatedFatturaID(null, aggregatedFatturaID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_RigaFattura_Fattura key.
		///		fK_Aggregated_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="aggregatedFatturaID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public GenTest.Entities.TList<RigaFattura> GetByAggregatedFatturaID(System.Int32? aggregatedFatturaID, int start, int pageLength,out int count)
		{
			return GetByAggregatedFatturaID(null, aggregatedFatturaID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_RigaFattura_Fattura key.
		///		FK_Aggregated_RigaFattura_Fattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="aggregatedFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.RigaFattura objects.</returns>
		public abstract GenTest.Entities.TList<RigaFattura> GetByAggregatedFatturaID(TransactionManager transactionManager, System.Int32? aggregatedFatturaID, int start, int pageLength, out int count);
		
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
		public override GenTest.Entities.RigaFattura Get(TransactionManager transactionManager, GenTest.Entities.RigaFatturaKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_RigaFattura index.
		/// </summary>
		/// <param name="iD"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByID(System.Int32 iD)
		{
			int count = -1;
			return GetByID(null,iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RigaFattura index.
		/// </summary>
		/// <param name="iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByID(System.Int32 iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RigaFattura index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByID(TransactionManager transactionManager, System.Int32 iD)
		{
			int count = -1;
			return GetByID(transactionManager, iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RigaFattura index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByID(TransactionManager transactionManager, System.Int32 iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RigaFattura index.
		/// </summary>
		/// <param name="iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByID(System.Int32 iD, int start, int pageLength, out int count)
		{
			return GetByID(null, iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RigaFattura index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public abstract GenTest.Entities.RigaFattura GetByID(TransactionManager transactionManager, System.Int32 iD, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UQ__RigaFattura__173876EA index.
		/// </summary>
		/// <param name="associatedFatturaID"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByAssociatedFatturaID(System.Int32? associatedFatturaID)
		{
			int count = -1;
			return GetByAssociatedFatturaID(null,associatedFatturaID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__RigaFattura__173876EA index.
		/// </summary>
		/// <param name="associatedFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByAssociatedFatturaID(System.Int32? associatedFatturaID, int start, int pageLength)
		{
			int count = -1;
			return GetByAssociatedFatturaID(null, associatedFatturaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__RigaFattura__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="associatedFatturaID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByAssociatedFatturaID(TransactionManager transactionManager, System.Int32? associatedFatturaID)
		{
			int count = -1;
			return GetByAssociatedFatturaID(transactionManager, associatedFatturaID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__RigaFattura__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="associatedFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByAssociatedFatturaID(TransactionManager transactionManager, System.Int32? associatedFatturaID, int start, int pageLength)
		{
			int count = -1;
			return GetByAssociatedFatturaID(transactionManager, associatedFatturaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__RigaFattura__173876EA index.
		/// </summary>
		/// <param name="associatedFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public GenTest.Entities.RigaFattura GetByAssociatedFatturaID(System.Int32? associatedFatturaID, int start, int pageLength, out int count)
		{
			return GetByAssociatedFatturaID(null, associatedFatturaID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__RigaFattura__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="associatedFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.RigaFattura"/> class.</returns>
		public abstract GenTest.Entities.RigaFattura GetByAssociatedFatturaID(TransactionManager transactionManager, System.Int32? associatedFatturaID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a GenTest.Entities.TList&lt;RigaFattura&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="GenTest.Entities.TList&lt;RigaFattura&gt;"/></returns>
		public static GenTest.Entities.TList<RigaFattura> Fill(IDataReader reader, GenTest.Entities.TList<RigaFattura> rows, int start, int pageLength)
		{
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
			
			GenTest.Entities.RigaFattura c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("RigaFattura")
			.Append("|").Append((reader.IsDBNull(((int)GenTest.Entities.RigaFatturaColumn.ID - 1))?(int)0:(System.Int32)reader[((int)GenTest.Entities.RigaFatturaColumn.ID - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<RigaFattura>(
			key.ToString(), // EntityTrackingKey
			"RigaFattura",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new GenTest.Entities.RigaFattura();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.Descrizione = (System.String)reader["Descrizione"];
			c.Importo = (System.Double)reader["Importo"];
			c.ID = (System.Int32)reader["ID"];
			c.ComposedFatturaID = reader.IsDBNull(reader.GetOrdinal("ComposedFatturaID")) ? null : (System.Int32?)reader["ComposedFatturaID"];
			c.AggregatedFatturaID = reader.IsDBNull(reader.GetOrdinal("AggregatedFatturaID")) ? null : (System.Int32?)reader["AggregatedFatturaID"];
			c.AssociatedFatturaID = reader.IsDBNull(reader.GetOrdinal("AssociatedFatturaID")) ? null : (System.Int32?)reader["AssociatedFatturaID"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.RigaFattura"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.RigaFattura"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, GenTest.Entities.RigaFattura entity)
		{
			if (!reader.Read()) return;
			
			entity.Descrizione = (System.String)reader["Descrizione"];
			entity.Importo = (System.Double)reader["Importo"];
			entity.ID = (System.Int32)reader["ID"];
			entity.ComposedFatturaID = reader.IsDBNull(reader.GetOrdinal("ComposedFatturaID")) ? null : (System.Int32?)reader["ComposedFatturaID"];
			entity.AggregatedFatturaID = reader.IsDBNull(reader.GetOrdinal("AggregatedFatturaID")) ? null : (System.Int32?)reader["AggregatedFatturaID"];
			entity.AssociatedFatturaID = reader.IsDBNull(reader.GetOrdinal("AssociatedFatturaID")) ? null : (System.Int32?)reader["AssociatedFatturaID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.RigaFattura"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.RigaFattura"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, GenTest.Entities.RigaFattura entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Descrizione = (System.String)dataRow["Descrizione"];
			entity.Importo = (System.Double)dataRow["Importo"];
			entity.ID = (System.Int32)dataRow["ID"];
			entity.ComposedFatturaID = Convert.IsDBNull(dataRow["ComposedFatturaID"]) ? null : (System.Int32?)dataRow["ComposedFatturaID"];
			entity.AggregatedFatturaID = Convert.IsDBNull(dataRow["AggregatedFatturaID"]) ? null : (System.Int32?)dataRow["AggregatedFatturaID"];
			entity.AssociatedFatturaID = Convert.IsDBNull(dataRow["AssociatedFatturaID"]) ? null : (System.Int32?)dataRow["AssociatedFatturaID"];
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
		/// <param name="entity">The <see cref="GenTest.Entities.RigaFattura"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">GenTest.Entities.RigaFattura Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, GenTest.Entities.RigaFattura entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ComposedFatturaIDSource	
			if (CanDeepLoad(entity, "Fattura|ComposedFatturaIDSource", deepLoadType, innerList) 
				&& entity.ComposedFatturaIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ComposedFatturaID ?? (int)0);
				Fattura tmpEntity = EntityManager.LocateEntity<Fattura>(EntityLocator.ConstructKeyFromPkItems(typeof(Fattura), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ComposedFatturaIDSource = tmpEntity;
				else
					entity.ComposedFatturaIDSource = DataRepository.FatturaProvider.GetByID(transactionManager, (entity.ComposedFatturaID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ComposedFatturaIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ComposedFatturaIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FatturaProvider.DeepLoad(transactionManager, entity.ComposedFatturaIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ComposedFatturaIDSource

			#region AggregatedFatturaIDSource	
			if (CanDeepLoad(entity, "Fattura|AggregatedFatturaIDSource", deepLoadType, innerList) 
				&& entity.AggregatedFatturaIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AggregatedFatturaID ?? (int)0);
				Fattura tmpEntity = EntityManager.LocateEntity<Fattura>(EntityLocator.ConstructKeyFromPkItems(typeof(Fattura), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AggregatedFatturaIDSource = tmpEntity;
				else
					entity.AggregatedFatturaIDSource = DataRepository.FatturaProvider.GetByID(transactionManager, (entity.AggregatedFatturaID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AggregatedFatturaIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AggregatedFatturaIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FatturaProvider.DeepLoad(transactionManager, entity.AggregatedFatturaIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AggregatedFatturaIDSource

			#region AssociatedFatturaIDSource	
			if (CanDeepLoad(entity, "Fattura|AssociatedFatturaIDSource", deepLoadType, innerList) 
				&& entity.AssociatedFatturaIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AssociatedFatturaID ?? (int)0);
				Fattura tmpEntity = EntityManager.LocateEntity<Fattura>(EntityLocator.ConstructKeyFromPkItems(typeof(Fattura), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AssociatedFatturaIDSource = tmpEntity;
				else
					entity.AssociatedFatturaIDSource = DataRepository.FatturaProvider.GetByID(transactionManager, (entity.AssociatedFatturaID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AssociatedFatturaIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AssociatedFatturaIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FatturaProvider.DeepLoad(transactionManager, entity.AssociatedFatturaIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AssociatedFatturaIDSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region FatturaCollectionGetByAggregatedRigaFatturaID
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Fattura>|FatturaCollectionGetByAggregatedRigaFatturaID", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FatturaCollectionGetByAggregatedRigaFatturaID' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FatturaCollectionGetByAggregatedRigaFatturaID = DataRepository.FatturaProvider.GetByAggregatedRigaFatturaID(transactionManager, entity.ID);

				if (deep && entity.FatturaCollectionGetByAggregatedRigaFatturaID.Count > 0)
				{
					deepHandles.Add("FatturaCollectionGetByAggregatedRigaFatturaID",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Fattura>) DataRepository.FatturaProvider.DeepLoad,
						new object[] { transactionManager, entity.FatturaCollectionGetByAggregatedRigaFatturaID, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Fattura
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "Fattura|Fattura", deepLoadType, innerList))
			{
				entity.Fattura = DataRepository.FatturaProvider.GetByAssociatedRigaFatturaID(transactionManager, entity.ID);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Fattura' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.Fattura != null)
				{
					deepHandles.Add("Fattura",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< Fattura >) DataRepository.FatturaProvider.DeepLoad,
						new object[] { transactionManager, entity.Fattura, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region FatturaCollectionGetByComposedRigaFatturaID
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Fattura>|FatturaCollectionGetByComposedRigaFatturaID", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FatturaCollectionGetByComposedRigaFatturaID' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FatturaCollectionGetByComposedRigaFatturaID = DataRepository.FatturaProvider.GetByComposedRigaFatturaID(transactionManager, entity.ID);

				if (deep && entity.FatturaCollectionGetByComposedRigaFatturaID.Count > 0)
				{
					deepHandles.Add("FatturaCollectionGetByComposedRigaFatturaID",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Fattura>) DataRepository.FatturaProvider.DeepLoad,
						new object[] { transactionManager, entity.FatturaCollectionGetByComposedRigaFatturaID, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the GenTest.Entities.RigaFattura object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">GenTest.Entities.RigaFattura instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">GenTest.Entities.RigaFattura Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, GenTest.Entities.RigaFattura entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ComposedFatturaIDSource
			if (CanDeepSave(entity, "Fattura|ComposedFatturaIDSource", deepSaveType, innerList) 
				&& entity.ComposedFatturaIDSource != null)
			{
				DataRepository.FatturaProvider.Save(transactionManager, entity.ComposedFatturaIDSource);
				entity.ComposedFatturaID = entity.ComposedFatturaIDSource.ID;
			}
			#endregion 
			
			#region AggregatedFatturaIDSource
			if (CanDeepSave(entity, "Fattura|AggregatedFatturaIDSource", deepSaveType, innerList) 
				&& entity.AggregatedFatturaIDSource != null)
			{
				DataRepository.FatturaProvider.Save(transactionManager, entity.AggregatedFatturaIDSource);
				entity.AggregatedFatturaID = entity.AggregatedFatturaIDSource.ID;
			}
			#endregion 
			
			#region AssociatedFatturaIDSource
			if (CanDeepSave(entity, "Fattura|AssociatedFatturaIDSource", deepSaveType, innerList) 
				&& entity.AssociatedFatturaIDSource != null)
			{
				DataRepository.FatturaProvider.Save(transactionManager, entity.AssociatedFatturaIDSource);
				entity.AssociatedFatturaID = entity.AssociatedFatturaIDSource.ID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();

			#region Fattura
			if (CanDeepSave(entity.Fattura, "Fattura|Fattura", deepSaveType, innerList))
			{

				if (entity.Fattura != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.Fattura.AssociatedRigaFatturaID = entity.ID;
					DataRepository.FatturaProvider.Save(transactionManager, entity.Fattura);
					deepHandles.Add(
						(DeepSaveSingleHandle< Fattura >) DataRepository.FatturaProvider.DeepSave,
						new object[] { transactionManager, entity.Fattura, deepSaveType, childTypes, innerList }
					);
				}
			} 
			#endregion 
	
			#region List<Fattura>
				if (CanDeepSave(entity.FatturaCollectionGetByAggregatedRigaFatturaID, "List<Fattura>|FatturaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Fattura child in entity.FatturaCollectionGetByAggregatedRigaFatturaID)
					{
						if(child.AggregatedRigaFatturaIDSource != null)
							child.AggregatedRigaFatturaID = child.AggregatedRigaFatturaIDSource.ID;
						else
							child.AggregatedRigaFatturaID = entity.ID;

					}

					if (entity.FatturaCollectionGetByAggregatedRigaFatturaID.Count > 0 || entity.FatturaCollectionGetByAggregatedRigaFatturaID.DeletedItems.Count > 0)
					{
						DataRepository.FatturaProvider.Save(transactionManager, entity.FatturaCollectionGetByAggregatedRigaFatturaID);
						
						deepHandles.Add(
							(DeepSaveHandle< Fattura >) DataRepository.FatturaProvider.DeepSave,
							new object[] { transactionManager, entity.FatturaCollectionGetByAggregatedRigaFatturaID, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<Fattura>
				if (CanDeepSave(entity.FatturaCollectionGetByComposedRigaFatturaID, "List<Fattura>|FatturaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Fattura child in entity.FatturaCollectionGetByComposedRigaFatturaID)
					{
						if(child.ComposedRigaFatturaIDSource != null)
							child.ComposedRigaFatturaID = child.ComposedRigaFatturaIDSource.ID;
						else
							child.ComposedRigaFatturaID = entity.ID;

					}

					if (entity.FatturaCollectionGetByComposedRigaFatturaID.Count > 0 || entity.FatturaCollectionGetByComposedRigaFatturaID.DeletedItems.Count > 0)
					{
						DataRepository.FatturaProvider.Save(transactionManager, entity.FatturaCollectionGetByComposedRigaFatturaID);
						
						deepHandles.Add(
							(DeepSaveHandle< Fattura >) DataRepository.FatturaProvider.DeepSave,
							new object[] { transactionManager, entity.FatturaCollectionGetByComposedRigaFatturaID, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles)
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
	
	#region RigaFatturaChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>GenTest.Entities.RigaFattura</c>
	///</summary>
	public enum RigaFatturaChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Fattura</c> at ComposedFatturaIDSource
		///</summary>
		[ChildEntityType(typeof(Fattura))]
		Fattura,
	
		///<summary>
		/// Collection of <c>RigaFattura</c> as OneToMany for FatturaCollection
		///</summary>
		[ChildEntityType(typeof(TList<Fattura>))]
		FatturaCollectionGetByAggregatedRigaFatturaID,

		///<summary>
		/// Collection of <c>RigaFattura</c> as OneToMany for FatturaCollection
		///</summary>
		[ChildEntityType(typeof(TList<Fattura>))]
		FatturaCollectionGetByComposedRigaFatturaID,
	}
	
	#endregion RigaFatturaChildEntityTypes
	
	#region RigaFatturaFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RigaFatturaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RigaFattura"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RigaFatturaFilterBuilder : SqlFilterBuilder<RigaFatturaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RigaFatturaFilterBuilder class.
		/// </summary>
		public RigaFatturaFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RigaFatturaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RigaFatturaFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RigaFatturaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RigaFatturaFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RigaFatturaFilterBuilder
	
	#region RigaFatturaParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RigaFatturaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RigaFattura"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RigaFatturaParameterBuilder : ParameterizedSqlFilterBuilder<RigaFatturaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RigaFatturaParameterBuilder class.
		/// </summary>
		public RigaFatturaParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RigaFatturaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RigaFatturaParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RigaFatturaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RigaFatturaParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RigaFatturaParameterBuilder
} // end namespace
