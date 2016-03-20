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
	/// This class is the base class for any <see cref="FatturaProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FatturaProviderBaseCore : EntityProviderBase<GenTest.Entities.Fattura, GenTest.Entities.FatturaKey>
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
		public override bool Delete(TransactionManager transactionManager, GenTest.Entities.FatturaKey key)
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
		/// 	Gets rows from the datasource based on the FK_Composed_Fattura_RigaFattura key.
		///		FK_Composed_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="composedRigaFatturaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public GenTest.Entities.TList<Fattura> GetByComposedRigaFatturaID(System.Int32? composedRigaFatturaID)
		{
			int count = -1;
			return GetByComposedRigaFatturaID(composedRigaFatturaID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_Fattura_RigaFattura key.
		///		FK_Composed_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="composedRigaFatturaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		/// <remarks></remarks>
		public GenTest.Entities.TList<Fattura> GetByComposedRigaFatturaID(TransactionManager transactionManager, System.Int32? composedRigaFatturaID)
		{
			int count = -1;
			return GetByComposedRigaFatturaID(transactionManager, composedRigaFatturaID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_Fattura_RigaFattura key.
		///		FK_Composed_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="composedRigaFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public GenTest.Entities.TList<Fattura> GetByComposedRigaFatturaID(TransactionManager transactionManager, System.Int32? composedRigaFatturaID, int start, int pageLength)
		{
			int count = -1;
			return GetByComposedRigaFatturaID(transactionManager, composedRigaFatturaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_Fattura_RigaFattura key.
		///		fK_Composed_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="composedRigaFatturaID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public GenTest.Entities.TList<Fattura> GetByComposedRigaFatturaID(System.Int32? composedRigaFatturaID, int start, int pageLength)
		{
			int count =  -1;
			return GetByComposedRigaFatturaID(null, composedRigaFatturaID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_Fattura_RigaFattura key.
		///		fK_Composed_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="composedRigaFatturaID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public GenTest.Entities.TList<Fattura> GetByComposedRigaFatturaID(System.Int32? composedRigaFatturaID, int start, int pageLength,out int count)
		{
			return GetByComposedRigaFatturaID(null, composedRigaFatturaID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Composed_Fattura_RigaFattura key.
		///		FK_Composed_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="composedRigaFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public abstract GenTest.Entities.TList<Fattura> GetByComposedRigaFatturaID(TransactionManager transactionManager, System.Int32? composedRigaFatturaID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_Fattura_RigaFattura key.
		///		FK_Aggregated_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="aggregatedRigaFatturaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public GenTest.Entities.TList<Fattura> GetByAggregatedRigaFatturaID(System.Int32? aggregatedRigaFatturaID)
		{
			int count = -1;
			return GetByAggregatedRigaFatturaID(aggregatedRigaFatturaID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_Fattura_RigaFattura key.
		///		FK_Aggregated_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="aggregatedRigaFatturaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		/// <remarks></remarks>
		public GenTest.Entities.TList<Fattura> GetByAggregatedRigaFatturaID(TransactionManager transactionManager, System.Int32? aggregatedRigaFatturaID)
		{
			int count = -1;
			return GetByAggregatedRigaFatturaID(transactionManager, aggregatedRigaFatturaID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_Fattura_RigaFattura key.
		///		FK_Aggregated_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="aggregatedRigaFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public GenTest.Entities.TList<Fattura> GetByAggregatedRigaFatturaID(TransactionManager transactionManager, System.Int32? aggregatedRigaFatturaID, int start, int pageLength)
		{
			int count = -1;
			return GetByAggregatedRigaFatturaID(transactionManager, aggregatedRigaFatturaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_Fattura_RigaFattura key.
		///		fK_Aggregated_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="aggregatedRigaFatturaID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public GenTest.Entities.TList<Fattura> GetByAggregatedRigaFatturaID(System.Int32? aggregatedRigaFatturaID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAggregatedRigaFatturaID(null, aggregatedRigaFatturaID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_Fattura_RigaFattura key.
		///		fK_Aggregated_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="aggregatedRigaFatturaID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public GenTest.Entities.TList<Fattura> GetByAggregatedRigaFatturaID(System.Int32? aggregatedRigaFatturaID, int start, int pageLength,out int count)
		{
			return GetByAggregatedRigaFatturaID(null, aggregatedRigaFatturaID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregated_Fattura_RigaFattura key.
		///		FK_Aggregated_Fattura_RigaFattura Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="aggregatedRigaFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.Fattura objects.</returns>
		public abstract GenTest.Entities.TList<Fattura> GetByAggregatedRigaFatturaID(TransactionManager transactionManager, System.Int32? aggregatedRigaFatturaID, int start, int pageLength, out int count);
		
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
		public override GenTest.Entities.Fattura Get(TransactionManager transactionManager, GenTest.Entities.FatturaKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Fattura index.
		/// </summary>
		/// <param name="iD"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByID(System.Int32 iD)
		{
			int count = -1;
			return GetByID(null,iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Fattura index.
		/// </summary>
		/// <param name="iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByID(System.Int32 iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Fattura index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByID(TransactionManager transactionManager, System.Int32 iD)
		{
			int count = -1;
			return GetByID(transactionManager, iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Fattura index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByID(TransactionManager transactionManager, System.Int32 iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Fattura index.
		/// </summary>
		/// <param name="iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByID(System.Int32 iD, int start, int pageLength, out int count)
		{
			return GetByID(null, iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Fattura index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public abstract GenTest.Entities.Fattura GetByID(TransactionManager transactionManager, System.Int32 iD, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UQ__Fattura__15502E78 index.
		/// </summary>
		/// <param name="associatedRigaFatturaID"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByAssociatedRigaFatturaID(System.Int32? associatedRigaFatturaID)
		{
			int count = -1;
			return GetByAssociatedRigaFatturaID(null,associatedRigaFatturaID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Fattura__15502E78 index.
		/// </summary>
		/// <param name="associatedRigaFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByAssociatedRigaFatturaID(System.Int32? associatedRigaFatturaID, int start, int pageLength)
		{
			int count = -1;
			return GetByAssociatedRigaFatturaID(null, associatedRigaFatturaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Fattura__15502E78 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="associatedRigaFatturaID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByAssociatedRigaFatturaID(TransactionManager transactionManager, System.Int32? associatedRigaFatturaID)
		{
			int count = -1;
			return GetByAssociatedRigaFatturaID(transactionManager, associatedRigaFatturaID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Fattura__15502E78 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="associatedRigaFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByAssociatedRigaFatturaID(TransactionManager transactionManager, System.Int32? associatedRigaFatturaID, int start, int pageLength)
		{
			int count = -1;
			return GetByAssociatedRigaFatturaID(transactionManager, associatedRigaFatturaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Fattura__15502E78 index.
		/// </summary>
		/// <param name="associatedRigaFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public GenTest.Entities.Fattura GetByAssociatedRigaFatturaID(System.Int32? associatedRigaFatturaID, int start, int pageLength, out int count)
		{
			return GetByAssociatedRigaFatturaID(null, associatedRigaFatturaID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Fattura__15502E78 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="associatedRigaFatturaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Fattura"/> class.</returns>
		public abstract GenTest.Entities.Fattura GetByAssociatedRigaFatturaID(TransactionManager transactionManager, System.Int32? associatedRigaFatturaID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a GenTest.Entities.TList&lt;Fattura&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="GenTest.Entities.TList&lt;Fattura&gt;"/></returns>
		public static GenTest.Entities.TList<Fattura> Fill(IDataReader reader, GenTest.Entities.TList<Fattura> rows, int start, int pageLength)
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
			
			GenTest.Entities.Fattura c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Fattura")
			.Append("|").Append((reader.IsDBNull(((int)GenTest.Entities.FatturaColumn.ID - 1))?(int)0:(System.Int32)reader[((int)GenTest.Entities.FatturaColumn.ID - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Fattura>(
			key.ToString(), // EntityTrackingKey
			"Fattura",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new GenTest.Entities.Fattura();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.Intestatario = (System.String)reader["Intestatario"];
			c.Descrizione = (System.String)reader["Descrizione"];
			c.Data = (System.String)reader["Data"];
			c.Numero = (System.Int32)reader["Numero"];
			c.ID = (System.Int32)reader["ID"];
			c.ComposedRigaFatturaID = reader.IsDBNull(reader.GetOrdinal("ComposedRigaFatturaID")) ? null : (System.Int32?)reader["ComposedRigaFatturaID"];
			c.AggregatedRigaFatturaID = reader.IsDBNull(reader.GetOrdinal("AggregatedRigaFatturaID")) ? null : (System.Int32?)reader["AggregatedRigaFatturaID"];
			c.AssociatedRigaFatturaID = reader.IsDBNull(reader.GetOrdinal("AssociatedRigaFatturaID")) ? null : (System.Int32?)reader["AssociatedRigaFatturaID"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Fattura"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Fattura"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, GenTest.Entities.Fattura entity)
		{
			if (!reader.Read()) return;
			
			entity.Intestatario = (System.String)reader["Intestatario"];
			entity.Descrizione = (System.String)reader["Descrizione"];
			entity.Data = (System.String)reader["Data"];
			entity.Numero = (System.Int32)reader["Numero"];
			entity.ID = (System.Int32)reader["ID"];
			entity.ComposedRigaFatturaID = reader.IsDBNull(reader.GetOrdinal("ComposedRigaFatturaID")) ? null : (System.Int32?)reader["ComposedRigaFatturaID"];
			entity.AggregatedRigaFatturaID = reader.IsDBNull(reader.GetOrdinal("AggregatedRigaFatturaID")) ? null : (System.Int32?)reader["AggregatedRigaFatturaID"];
			entity.AssociatedRigaFatturaID = reader.IsDBNull(reader.GetOrdinal("AssociatedRigaFatturaID")) ? null : (System.Int32?)reader["AssociatedRigaFatturaID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Fattura"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Fattura"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, GenTest.Entities.Fattura entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Intestatario = (System.String)dataRow["Intestatario"];
			entity.Descrizione = (System.String)dataRow["Descrizione"];
			entity.Data = (System.String)dataRow["Data"];
			entity.Numero = (System.Int32)dataRow["Numero"];
			entity.ID = (System.Int32)dataRow["ID"];
			entity.ComposedRigaFatturaID = Convert.IsDBNull(dataRow["ComposedRigaFatturaID"]) ? null : (System.Int32?)dataRow["ComposedRigaFatturaID"];
			entity.AggregatedRigaFatturaID = Convert.IsDBNull(dataRow["AggregatedRigaFatturaID"]) ? null : (System.Int32?)dataRow["AggregatedRigaFatturaID"];
			entity.AssociatedRigaFatturaID = Convert.IsDBNull(dataRow["AssociatedRigaFatturaID"]) ? null : (System.Int32?)dataRow["AssociatedRigaFatturaID"];
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
		/// <param name="entity">The <see cref="GenTest.Entities.Fattura"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">GenTest.Entities.Fattura Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, GenTest.Entities.Fattura entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ComposedRigaFatturaIDSource	
			if (CanDeepLoad(entity, "RigaFattura|ComposedRigaFatturaIDSource", deepLoadType, innerList) 
				&& entity.ComposedRigaFatturaIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ComposedRigaFatturaID ?? (int)0);
				RigaFattura tmpEntity = EntityManager.LocateEntity<RigaFattura>(EntityLocator.ConstructKeyFromPkItems(typeof(RigaFattura), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ComposedRigaFatturaIDSource = tmpEntity;
				else
					entity.ComposedRigaFatturaIDSource = DataRepository.RigaFatturaProvider.GetByID(transactionManager, (entity.ComposedRigaFatturaID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ComposedRigaFatturaIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ComposedRigaFatturaIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RigaFatturaProvider.DeepLoad(transactionManager, entity.ComposedRigaFatturaIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ComposedRigaFatturaIDSource

			#region AggregatedRigaFatturaIDSource	
			if (CanDeepLoad(entity, "RigaFattura|AggregatedRigaFatturaIDSource", deepLoadType, innerList) 
				&& entity.AggregatedRigaFatturaIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AggregatedRigaFatturaID ?? (int)0);
				RigaFattura tmpEntity = EntityManager.LocateEntity<RigaFattura>(EntityLocator.ConstructKeyFromPkItems(typeof(RigaFattura), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AggregatedRigaFatturaIDSource = tmpEntity;
				else
					entity.AggregatedRigaFatturaIDSource = DataRepository.RigaFatturaProvider.GetByID(transactionManager, (entity.AggregatedRigaFatturaID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AggregatedRigaFatturaIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AggregatedRigaFatturaIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RigaFatturaProvider.DeepLoad(transactionManager, entity.AggregatedRigaFatturaIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AggregatedRigaFatturaIDSource

			#region AssociatedRigaFatturaIDSource	
			if (CanDeepLoad(entity, "RigaFattura|AssociatedRigaFatturaIDSource", deepLoadType, innerList) 
				&& entity.AssociatedRigaFatturaIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AssociatedRigaFatturaID ?? (int)0);
				RigaFattura tmpEntity = EntityManager.LocateEntity<RigaFattura>(EntityLocator.ConstructKeyFromPkItems(typeof(RigaFattura), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AssociatedRigaFatturaIDSource = tmpEntity;
				else
					entity.AssociatedRigaFatturaIDSource = DataRepository.RigaFatturaProvider.GetByID(transactionManager, (entity.AssociatedRigaFatturaID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AssociatedRigaFatturaIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AssociatedRigaFatturaIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RigaFatturaProvider.DeepLoad(transactionManager, entity.AssociatedRigaFatturaIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AssociatedRigaFatturaIDSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region RigaFattura
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "RigaFattura|RigaFattura", deepLoadType, innerList))
			{
				entity.RigaFattura = DataRepository.RigaFatturaProvider.GetByAssociatedFatturaID(transactionManager, entity.ID);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RigaFattura' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.RigaFattura != null)
				{
					deepHandles.Add("RigaFattura",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< RigaFattura >) DataRepository.RigaFatturaProvider.DeepLoad,
						new object[] { transactionManager, entity.RigaFattura, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region RigaFatturaCollectionGetByComposedFatturaID
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RigaFattura>|RigaFatturaCollectionGetByComposedFatturaID", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RigaFatturaCollectionGetByComposedFatturaID' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RigaFatturaCollectionGetByComposedFatturaID = DataRepository.RigaFatturaProvider.GetByComposedFatturaID(transactionManager, entity.ID);

				if (deep && entity.RigaFatturaCollectionGetByComposedFatturaID.Count > 0)
				{
					deepHandles.Add("RigaFatturaCollectionGetByComposedFatturaID",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RigaFattura>) DataRepository.RigaFatturaProvider.DeepLoad,
						new object[] { transactionManager, entity.RigaFatturaCollectionGetByComposedFatturaID, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region RigaFatturaCollectionGetByAggregatedFatturaID
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RigaFattura>|RigaFatturaCollectionGetByAggregatedFatturaID", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RigaFatturaCollectionGetByAggregatedFatturaID' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RigaFatturaCollectionGetByAggregatedFatturaID = DataRepository.RigaFatturaProvider.GetByAggregatedFatturaID(transactionManager, entity.ID);

				if (deep && entity.RigaFatturaCollectionGetByAggregatedFatturaID.Count > 0)
				{
					deepHandles.Add("RigaFatturaCollectionGetByAggregatedFatturaID",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RigaFattura>) DataRepository.RigaFatturaProvider.DeepLoad,
						new object[] { transactionManager, entity.RigaFatturaCollectionGetByAggregatedFatturaID, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the GenTest.Entities.Fattura object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">GenTest.Entities.Fattura instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">GenTest.Entities.Fattura Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, GenTest.Entities.Fattura entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ComposedRigaFatturaIDSource
			if (CanDeepSave(entity, "RigaFattura|ComposedRigaFatturaIDSource", deepSaveType, innerList) 
				&& entity.ComposedRigaFatturaIDSource != null)
			{
				DataRepository.RigaFatturaProvider.Save(transactionManager, entity.ComposedRigaFatturaIDSource);
				entity.ComposedRigaFatturaID = entity.ComposedRigaFatturaIDSource.ID;
			}
			#endregion 
			
			#region AggregatedRigaFatturaIDSource
			if (CanDeepSave(entity, "RigaFattura|AggregatedRigaFatturaIDSource", deepSaveType, innerList) 
				&& entity.AggregatedRigaFatturaIDSource != null)
			{
				DataRepository.RigaFatturaProvider.Save(transactionManager, entity.AggregatedRigaFatturaIDSource);
				entity.AggregatedRigaFatturaID = entity.AggregatedRigaFatturaIDSource.ID;
			}
			#endregion 
			
			#region AssociatedRigaFatturaIDSource
			if (CanDeepSave(entity, "RigaFattura|AssociatedRigaFatturaIDSource", deepSaveType, innerList) 
				&& entity.AssociatedRigaFatturaIDSource != null)
			{
				DataRepository.RigaFatturaProvider.Save(transactionManager, entity.AssociatedRigaFatturaIDSource);
				entity.AssociatedRigaFatturaID = entity.AssociatedRigaFatturaIDSource.ID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();

			#region RigaFattura
			if (CanDeepSave(entity.RigaFattura, "RigaFattura|RigaFattura", deepSaveType, innerList))
			{

				if (entity.RigaFattura != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.RigaFattura.AssociatedFatturaID = entity.ID;
					DataRepository.RigaFatturaProvider.Save(transactionManager, entity.RigaFattura);
					deepHandles.Add(
						(DeepSaveSingleHandle< RigaFattura >) DataRepository.RigaFatturaProvider.DeepSave,
						new object[] { transactionManager, entity.RigaFattura, deepSaveType, childTypes, innerList }
					);
				}
			} 
			#endregion 
	
			#region List<RigaFattura>
				if (CanDeepSave(entity.RigaFatturaCollectionGetByComposedFatturaID, "List<RigaFattura>|RigaFatturaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RigaFattura child in entity.RigaFatturaCollectionGetByComposedFatturaID)
					{
						if(child.ComposedFatturaIDSource != null)
							child.ComposedFatturaID = child.ComposedFatturaIDSource.ID;
						else
							child.ComposedFatturaID = entity.ID;

					}

					if (entity.RigaFatturaCollectionGetByComposedFatturaID.Count > 0 || entity.RigaFatturaCollectionGetByComposedFatturaID.DeletedItems.Count > 0)
					{
						DataRepository.RigaFatturaProvider.Save(transactionManager, entity.RigaFatturaCollectionGetByComposedFatturaID);
						
						deepHandles.Add(
							(DeepSaveHandle< RigaFattura >) DataRepository.RigaFatturaProvider.DeepSave,
							new object[] { transactionManager, entity.RigaFatturaCollectionGetByComposedFatturaID, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<RigaFattura>
				if (CanDeepSave(entity.RigaFatturaCollectionGetByAggregatedFatturaID, "List<RigaFattura>|RigaFatturaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RigaFattura child in entity.RigaFatturaCollectionGetByAggregatedFatturaID)
					{
						if(child.AggregatedFatturaIDSource != null)
							child.AggregatedFatturaID = child.AggregatedFatturaIDSource.ID;
						else
							child.AggregatedFatturaID = entity.ID;

					}

					if (entity.RigaFatturaCollectionGetByAggregatedFatturaID.Count > 0 || entity.RigaFatturaCollectionGetByAggregatedFatturaID.DeletedItems.Count > 0)
					{
						DataRepository.RigaFatturaProvider.Save(transactionManager, entity.RigaFatturaCollectionGetByAggregatedFatturaID);
						
						deepHandles.Add(
							(DeepSaveHandle< RigaFattura >) DataRepository.RigaFatturaProvider.DeepSave,
							new object[] { transactionManager, entity.RigaFatturaCollectionGetByAggregatedFatturaID, deepSaveType, childTypes, innerList }
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
	
	#region FatturaChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>GenTest.Entities.Fattura</c>
	///</summary>
	public enum FatturaChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>RigaFattura</c> at ComposedRigaFatturaIDSource
		///</summary>
		[ChildEntityType(typeof(RigaFattura))]
		RigaFattura,
	
		///<summary>
		/// Collection of <c>Fattura</c> as OneToMany for RigaFatturaCollection
		///</summary>
		[ChildEntityType(typeof(TList<RigaFattura>))]
		RigaFatturaCollectionGetByComposedFatturaID,

		///<summary>
		/// Collection of <c>Fattura</c> as OneToMany for RigaFatturaCollection
		///</summary>
		[ChildEntityType(typeof(TList<RigaFattura>))]
		RigaFatturaCollectionGetByAggregatedFatturaID,
	}
	
	#endregion FatturaChildEntityTypes
	
	#region FatturaFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FatturaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Fattura"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FatturaFilterBuilder : SqlFilterBuilder<FatturaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FatturaFilterBuilder class.
		/// </summary>
		public FatturaFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FatturaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FatturaFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FatturaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FatturaFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FatturaFilterBuilder
	
	#region FatturaParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FatturaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Fattura"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FatturaParameterBuilder : ParameterizedSqlFilterBuilder<FatturaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FatturaParameterBuilder class.
		/// </summary>
		public FatturaParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FatturaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FatturaParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FatturaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FatturaParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FatturaParameterBuilder
} // end namespace
