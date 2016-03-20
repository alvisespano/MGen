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
	/// This class is the base class for any <see cref="MacchinaProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MacchinaProviderBaseCore : EntityProviderBase<GenTest.Entities.Macchina, GenTest.Entities.MacchinaKey>
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
		public override bool Delete(TransactionManager transactionManager, GenTest.Entities.MacchinaKey key)
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
		/// 	Gets rows from the datasource based on the FK_CropAggregation_Macchina_Macchina key.
		///		FK_CropAggregation_Macchina_Macchina Description: 
		/// </summary>
		/// <param name="_cropAggregationMacchinaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Macchina objects.</returns>
		public TList<Macchina> GetByCropAggregationMacchinaID(System.Int32? _cropAggregationMacchinaID)
		{
			int count = -1;
			return GetByCropAggregationMacchinaID(_cropAggregationMacchinaID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CropAggregation_Macchina_Macchina key.
		///		FK_CropAggregation_Macchina_Macchina Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cropAggregationMacchinaID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Macchina objects.</returns>
		/// <remarks></remarks>
		public TList<Macchina> GetByCropAggregationMacchinaID(TransactionManager transactionManager, System.Int32? _cropAggregationMacchinaID)
		{
			int count = -1;
			return GetByCropAggregationMacchinaID(transactionManager, _cropAggregationMacchinaID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CropAggregation_Macchina_Macchina key.
		///		FK_CropAggregation_Macchina_Macchina Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cropAggregationMacchinaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Macchina objects.</returns>
		public TList<Macchina> GetByCropAggregationMacchinaID(TransactionManager transactionManager, System.Int32? _cropAggregationMacchinaID, int start, int pageLength)
		{
			int count = -1;
			return GetByCropAggregationMacchinaID(transactionManager, _cropAggregationMacchinaID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CropAggregation_Macchina_Macchina key.
		///		fKCropAggregationMacchinaMacchina Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cropAggregationMacchinaID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Macchina objects.</returns>
		public TList<Macchina> GetByCropAggregationMacchinaID(System.Int32? _cropAggregationMacchinaID, int start, int pageLength)
		{
			int count =  -1;
			return GetByCropAggregationMacchinaID(null, _cropAggregationMacchinaID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CropAggregation_Macchina_Macchina key.
		///		fKCropAggregationMacchinaMacchina Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cropAggregationMacchinaID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Macchina objects.</returns>
		public TList<Macchina> GetByCropAggregationMacchinaID(System.Int32? _cropAggregationMacchinaID, int start, int pageLength,out int count)
		{
			return GetByCropAggregationMacchinaID(null, _cropAggregationMacchinaID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CropAggregation_Macchina_Macchina key.
		///		FK_CropAggregation_Macchina_Macchina Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cropAggregationMacchinaID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.Macchina objects.</returns>
		public abstract TList<Macchina> GetByCropAggregationMacchinaID(TransactionManager transactionManager, System.Int32? _cropAggregationMacchinaID, int start, int pageLength, out int count);
		
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
		public override GenTest.Entities.Macchina Get(TransactionManager transactionManager, GenTest.Entities.MacchinaKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Macchina index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Macchina index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Macchina index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Macchina index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Macchina index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Macchina index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public abstract GenTest.Entities.Macchina GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UQ__Macchina__108B795B index.
		/// </summary>
		/// <param name="_associationMotoreID"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByAssociationMotoreID(System.Int32? _associationMotoreID)
		{
			int count = -1;
			return GetByAssociationMotoreID(null,_associationMotoreID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Macchina__108B795B index.
		/// </summary>
		/// <param name="_associationMotoreID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByAssociationMotoreID(System.Int32? _associationMotoreID, int start, int pageLength)
		{
			int count = -1;
			return GetByAssociationMotoreID(null, _associationMotoreID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Macchina__108B795B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_associationMotoreID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByAssociationMotoreID(TransactionManager transactionManager, System.Int32? _associationMotoreID)
		{
			int count = -1;
			return GetByAssociationMotoreID(transactionManager, _associationMotoreID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Macchina__108B795B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_associationMotoreID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByAssociationMotoreID(TransactionManager transactionManager, System.Int32? _associationMotoreID, int start, int pageLength)
		{
			int count = -1;
			return GetByAssociationMotoreID(transactionManager, _associationMotoreID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Macchina__108B795B index.
		/// </summary>
		/// <param name="_associationMotoreID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public GenTest.Entities.Macchina GetByAssociationMotoreID(System.Int32? _associationMotoreID, int start, int pageLength, out int count)
		{
			return GetByAssociationMotoreID(null, _associationMotoreID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__Macchina__108B795B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_associationMotoreID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Macchina"/> class.</returns>
		public abstract GenTest.Entities.Macchina GetByAssociationMotoreID(TransactionManager transactionManager, System.Int32? _associationMotoreID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Macchina&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Macchina&gt;"/></returns>
		public static TList<Macchina> Fill(IDataReader reader, TList<Macchina> rows, int start, int pageLength)
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
				
				GenTest.Entities.Macchina c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Macchina")
					.Append("|").Append((reader.IsDBNull(((int)GenTest.Entities.MacchinaColumn.ID - 1))?(int)0:(System.Int32)reader[((int)GenTest.Entities.MacchinaColumn.ID - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Macchina>(
					key.ToString(), // EntityTrackingKey
					"Macchina",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new GenTest.Entities.Macchina();
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
					c.Modello = (System.String)reader[((int)MacchinaColumn.Modello - 1)];
					c.ID = (System.Int32)reader[((int)MacchinaColumn.ID - 1)];
					c.CropAggregationMacchinaID = (reader.IsDBNull(((int)MacchinaColumn.CropAggregationMacchinaID - 1)))?null:(System.Int32?)reader[((int)MacchinaColumn.CropAggregationMacchinaID - 1)];
					c.AssociationMotoreID = (reader.IsDBNull(((int)MacchinaColumn.AssociationMotoreID - 1)))?null:(System.Int32?)reader[((int)MacchinaColumn.AssociationMotoreID - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Macchina"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Macchina"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, GenTest.Entities.Macchina entity)
		{
			if (!reader.Read()) return;
			
			entity.Modello = (System.String)reader[((int)MacchinaColumn.Modello - 1)];
			entity.ID = (System.Int32)reader[((int)MacchinaColumn.ID - 1)];
			entity.CropAggregationMacchinaID = (reader.IsDBNull(((int)MacchinaColumn.CropAggregationMacchinaID - 1)))?null:(System.Int32?)reader[((int)MacchinaColumn.CropAggregationMacchinaID - 1)];
			entity.AssociationMotoreID = (reader.IsDBNull(((int)MacchinaColumn.AssociationMotoreID - 1)))?null:(System.Int32?)reader[((int)MacchinaColumn.AssociationMotoreID - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Macchina"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Macchina"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, GenTest.Entities.Macchina entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Modello = (System.String)dataRow["Modello"];
			entity.ID = (System.Int32)dataRow["ID"];
			entity.CropAggregationMacchinaID = Convert.IsDBNull(dataRow["CropAggregationMacchinaID"]) ? null : (System.Int32?)dataRow["CropAggregationMacchinaID"];
			entity.AssociationMotoreID = Convert.IsDBNull(dataRow["AssociationMotoreID"]) ? null : (System.Int32?)dataRow["AssociationMotoreID"];
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
		/// <param name="entity">The <see cref="GenTest.Entities.Macchina"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">GenTest.Entities.Macchina Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, GenTest.Entities.Macchina entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CropAggregationMacchinaIDSource	
			if (CanDeepLoad(entity, "Macchina|CropAggregationMacchinaIDSource", deepLoadType, innerList) 
				&& entity.CropAggregationMacchinaIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CropAggregationMacchinaID ?? (int)0);
				Macchina tmpEntity = EntityManager.LocateEntity<Macchina>(EntityLocator.ConstructKeyFromPkItems(typeof(Macchina), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CropAggregationMacchinaIDSource = tmpEntity;
				else
					entity.CropAggregationMacchinaIDSource = DataRepository.MacchinaProvider.GetByID(transactionManager, (entity.CropAggregationMacchinaID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CropAggregationMacchinaIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CropAggregationMacchinaIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MacchinaProvider.DeepLoad(transactionManager, entity.CropAggregationMacchinaIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CropAggregationMacchinaIDSource

			#region AssociationMotoreIDSource	
			if (CanDeepLoad(entity, "Motore|AssociationMotoreIDSource", deepLoadType, innerList) 
				&& entity.AssociationMotoreIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AssociationMotoreID ?? (int)0);
				Motore tmpEntity = EntityManager.LocateEntity<Motore>(EntityLocator.ConstructKeyFromPkItems(typeof(Motore), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AssociationMotoreIDSource = tmpEntity;
				else
					entity.AssociationMotoreIDSource = DataRepository.MotoreProvider.GetByID(transactionManager, (entity.AssociationMotoreID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AssociationMotoreIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AssociationMotoreIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MotoreProvider.DeepLoad(transactionManager, entity.AssociationMotoreIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AssociationMotoreIDSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region SpecchiettoCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Specchietto>|SpecchiettoCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SpecchiettoCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SpecchiettoCollection = DataRepository.SpecchiettoProvider.GetByAggregationMacchinaID(transactionManager, entity.ID);

				if (deep && entity.SpecchiettoCollection.Count > 0)
				{
					deepHandles.Add("SpecchiettoCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Specchietto>) DataRepository.SpecchiettoProvider.DeepLoad,
						new object[] { transactionManager, entity.SpecchiettoCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MacchinaCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Macchina>|MacchinaCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MacchinaCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MacchinaCollection = DataRepository.MacchinaProvider.GetByCropAggregationMacchinaID(transactionManager, entity.ID);

				if (deep && entity.MacchinaCollection.Count > 0)
				{
					deepHandles.Add("MacchinaCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Macchina>) DataRepository.MacchinaProvider.DeepLoad,
						new object[] { transactionManager, entity.MacchinaCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the GenTest.Entities.Macchina object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">GenTest.Entities.Macchina instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">GenTest.Entities.Macchina Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, GenTest.Entities.Macchina entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CropAggregationMacchinaIDSource
			if (CanDeepSave(entity, "Macchina|CropAggregationMacchinaIDSource", deepSaveType, innerList) 
				&& entity.CropAggregationMacchinaIDSource != null)
			{
				DataRepository.MacchinaProvider.Save(transactionManager, entity.CropAggregationMacchinaIDSource);
				entity.CropAggregationMacchinaID = entity.CropAggregationMacchinaIDSource.ID;
			}
			#endregion 
			
			#region AssociationMotoreIDSource
			if (CanDeepSave(entity, "Motore|AssociationMotoreIDSource", deepSaveType, innerList) 
				&& entity.AssociationMotoreIDSource != null)
			{
				DataRepository.MotoreProvider.Save(transactionManager, entity.AssociationMotoreIDSource);
				entity.AssociationMotoreID = entity.AssociationMotoreIDSource.ID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Specchietto>
				if (CanDeepSave(entity.SpecchiettoCollection, "List<Specchietto>|SpecchiettoCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Specchietto child in entity.SpecchiettoCollection)
					{
						if(child.AggregationMacchinaIDSource != null)
						{
							child.AggregationMacchinaID = child.AggregationMacchinaIDSource.ID;
						}
						else
						{
							child.AggregationMacchinaID = entity.ID;
						}

					}

					if (entity.SpecchiettoCollection.Count > 0 || entity.SpecchiettoCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SpecchiettoProvider.Save(transactionManager, entity.SpecchiettoCollection);
						
						deepHandles.Add("SpecchiettoCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Specchietto >) DataRepository.SpecchiettoProvider.DeepSave,
							new object[] { transactionManager, entity.SpecchiettoCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Macchina>
				if (CanDeepSave(entity.MacchinaCollection, "List<Macchina>|MacchinaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Macchina child in entity.MacchinaCollection)
					{
						if(child.CropAggregationMacchinaIDSource != null)
						{
							child.CropAggregationMacchinaID = child.CropAggregationMacchinaIDSource.ID;
						}
						else
						{
							child.CropAggregationMacchinaID = entity.ID;
						}

					}

					if (entity.MacchinaCollection.Count > 0 || entity.MacchinaCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MacchinaProvider.Save(transactionManager, entity.MacchinaCollection);
						
						deepHandles.Add("MacchinaCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Macchina >) DataRepository.MacchinaProvider.DeepSave,
							new object[] { transactionManager, entity.MacchinaCollection, deepSaveType, childTypes, innerList }
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
	
	#region MacchinaChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>GenTest.Entities.Macchina</c>
	///</summary>
	public enum MacchinaChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Macchina</c> at CropAggregationMacchinaIDSource
		///</summary>
		[ChildEntityType(typeof(Macchina))]
		Macchina,
			
		///<summary>
		/// Composite Property for <c>Motore</c> at AssociationMotoreIDSource
		///</summary>
		[ChildEntityType(typeof(Motore))]
		Motore,
	
		///<summary>
		/// Collection of <c>Macchina</c> as OneToMany for SpecchiettoCollection
		///</summary>
		[ChildEntityType(typeof(TList<Specchietto>))]
		SpecchiettoCollection,

		///<summary>
		/// Collection of <c>Macchina</c> as OneToMany for MacchinaCollection
		///</summary>
		[ChildEntityType(typeof(TList<Macchina>))]
		MacchinaCollection,
	}
	
	#endregion MacchinaChildEntityTypes
	
	#region MacchinaFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MacchinaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Macchina"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MacchinaFilterBuilder : SqlFilterBuilder<MacchinaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MacchinaFilterBuilder class.
		/// </summary>
		public MacchinaFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MacchinaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MacchinaFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MacchinaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MacchinaFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MacchinaFilterBuilder
	
	#region MacchinaParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MacchinaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Macchina"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MacchinaParameterBuilder : ParameterizedSqlFilterBuilder<MacchinaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MacchinaParameterBuilder class.
		/// </summary>
		public MacchinaParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MacchinaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MacchinaParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MacchinaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MacchinaParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MacchinaParameterBuilder
} // end namespace
