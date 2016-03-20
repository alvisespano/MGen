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
	/// This class is the base class for any <see cref="MotoreProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MotoreProviderBaseCore : EntityProviderBase<GenTest.Entities.Motore, GenTest.Entities.MotoreKey>
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
		public override bool Delete(TransactionManager transactionManager, GenTest.Entities.MotoreKey key)
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
		/// 	Gets rows from the datasource based on the FK_Aggregation_Motore_Motore key.
		///		FK_Aggregation_Motore_Motore Description: 
		/// </summary>
		/// <param name="_aggregationMotoreID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Motore objects.</returns>
		public TList<Motore> GetByAggregationMotoreID(System.Int32? _aggregationMotoreID)
		{
			int count = -1;
			return GetByAggregationMotoreID(_aggregationMotoreID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Motore_Motore key.
		///		FK_Aggregation_Motore_Motore Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationMotoreID"></param>
		/// <returns>Returns a typed collection of GenTest.Entities.Motore objects.</returns>
		/// <remarks></remarks>
		public TList<Motore> GetByAggregationMotoreID(TransactionManager transactionManager, System.Int32? _aggregationMotoreID)
		{
			int count = -1;
			return GetByAggregationMotoreID(transactionManager, _aggregationMotoreID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Motore_Motore key.
		///		FK_Aggregation_Motore_Motore Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationMotoreID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Motore objects.</returns>
		public TList<Motore> GetByAggregationMotoreID(TransactionManager transactionManager, System.Int32? _aggregationMotoreID, int start, int pageLength)
		{
			int count = -1;
			return GetByAggregationMotoreID(transactionManager, _aggregationMotoreID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Motore_Motore key.
		///		fKAggregationMotoreMotore Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_aggregationMotoreID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Motore objects.</returns>
		public TList<Motore> GetByAggregationMotoreID(System.Int32? _aggregationMotoreID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAggregationMotoreID(null, _aggregationMotoreID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Motore_Motore key.
		///		fKAggregationMotoreMotore Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_aggregationMotoreID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of GenTest.Entities.Motore objects.</returns>
		public TList<Motore> GetByAggregationMotoreID(System.Int32? _aggregationMotoreID, int start, int pageLength,out int count)
		{
			return GetByAggregationMotoreID(null, _aggregationMotoreID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Aggregation_Motore_Motore key.
		///		FK_Aggregation_Motore_Motore Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_aggregationMotoreID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of GenTest.Entities.Motore objects.</returns>
		public abstract TList<Motore> GetByAggregationMotoreID(TransactionManager transactionManager, System.Int32? _aggregationMotoreID, int start, int pageLength, out int count);
		
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
		public override GenTest.Entities.Motore Get(TransactionManager transactionManager, GenTest.Entities.MotoreKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Motore index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Motore"/> class.</returns>
		public GenTest.Entities.Motore GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Motore index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Motore"/> class.</returns>
		public GenTest.Entities.Motore GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Motore index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Motore"/> class.</returns>
		public GenTest.Entities.Motore GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Motore index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Motore"/> class.</returns>
		public GenTest.Entities.Motore GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Motore index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Motore"/> class.</returns>
		public GenTest.Entities.Motore GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Motore index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="GenTest.Entities.Motore"/> class.</returns>
		public abstract GenTest.Entities.Motore GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Motore&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Motore&gt;"/></returns>
		public static TList<Motore> Fill(IDataReader reader, TList<Motore> rows, int start, int pageLength)
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
				
				GenTest.Entities.Motore c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Motore")
					.Append("|").Append((reader.IsDBNull(((int)GenTest.Entities.MotoreColumn.ID - 1))?(int)0:(System.Int32)reader[((int)GenTest.Entities.MotoreColumn.ID - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Motore>(
					key.ToString(), // EntityTrackingKey
					"Motore",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new GenTest.Entities.Motore();
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
					c.Descrizione = (System.String)reader[((int)MotoreColumn.Descrizione - 1)];
					c.ID = (System.Int32)reader[((int)MotoreColumn.ID - 1)];
					c.AggregationMotoreID = (reader.IsDBNull(((int)MotoreColumn.AggregationMotoreID - 1)))?null:(System.Int32?)reader[((int)MotoreColumn.AggregationMotoreID - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Motore"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Motore"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, GenTest.Entities.Motore entity)
		{
			if (!reader.Read()) return;
			
			entity.Descrizione = (System.String)reader[((int)MotoreColumn.Descrizione - 1)];
			entity.ID = (System.Int32)reader[((int)MotoreColumn.ID - 1)];
			entity.AggregationMotoreID = (reader.IsDBNull(((int)MotoreColumn.AggregationMotoreID - 1)))?null:(System.Int32?)reader[((int)MotoreColumn.AggregationMotoreID - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="GenTest.Entities.Motore"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="GenTest.Entities.Motore"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, GenTest.Entities.Motore entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Descrizione = (System.String)dataRow["Descrizione"];
			entity.ID = (System.Int32)dataRow["ID"];
			entity.AggregationMotoreID = Convert.IsDBNull(dataRow["AggregationMotoreID"]) ? null : (System.Int32?)dataRow["AggregationMotoreID"];
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
		/// <param name="entity">The <see cref="GenTest.Entities.Motore"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">GenTest.Entities.Motore Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, GenTest.Entities.Motore entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AggregationMotoreIDSource	
			if (CanDeepLoad(entity, "Motore|AggregationMotoreIDSource", deepLoadType, innerList) 
				&& entity.AggregationMotoreIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AggregationMotoreID ?? (int)0);
				Motore tmpEntity = EntityManager.LocateEntity<Motore>(EntityLocator.ConstructKeyFromPkItems(typeof(Motore), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AggregationMotoreIDSource = tmpEntity;
				else
					entity.AggregationMotoreIDSource = DataRepository.MotoreProvider.GetByID(transactionManager, (entity.AggregationMotoreID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AggregationMotoreIDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AggregationMotoreIDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MotoreProvider.DeepLoad(transactionManager, entity.AggregationMotoreIDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AggregationMotoreIDSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region MotoreCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Motore>|MotoreCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MotoreCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MotoreCollection = DataRepository.MotoreProvider.GetByAggregationMotoreID(transactionManager, entity.ID);

				if (deep && entity.MotoreCollection.Count > 0)
				{
					deepHandles.Add("MotoreCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Motore>) DataRepository.MotoreProvider.DeepLoad,
						new object[] { transactionManager, entity.MotoreCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region PistoneCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Pistone>|PistoneCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PistoneCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PistoneCollection = DataRepository.PistoneProvider.GetByCompositionMotoreID(transactionManager, entity.ID);

				if (deep && entity.PistoneCollection.Count > 0)
				{
					deepHandles.Add("PistoneCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Pistone>) DataRepository.PistoneProvider.DeepLoad,
						new object[] { transactionManager, entity.PistoneCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Macchina
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "Macchina|Macchina", deepLoadType, innerList))
			{
				entity.Macchina = DataRepository.MacchinaProvider.GetByAssociationMotoreID(transactionManager, entity.ID);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Macchina' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.Macchina != null)
				{
					deepHandles.Add("Macchina",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< Macchina >) DataRepository.MacchinaProvider.DeepLoad,
						new object[] { transactionManager, entity.Macchina, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the GenTest.Entities.Motore object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">GenTest.Entities.Motore instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">GenTest.Entities.Motore Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, GenTest.Entities.Motore entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AggregationMotoreIDSource
			if (CanDeepSave(entity, "Motore|AggregationMotoreIDSource", deepSaveType, innerList) 
				&& entity.AggregationMotoreIDSource != null)
			{
				DataRepository.MotoreProvider.Save(transactionManager, entity.AggregationMotoreIDSource);
				entity.AggregationMotoreID = entity.AggregationMotoreIDSource.ID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region Macchina
			if (CanDeepSave(entity.Macchina, "Macchina|Macchina", deepSaveType, innerList))
			{

				if (entity.Macchina != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.Macchina.AssociationMotoreID = entity.ID;
					//DataRepository.MacchinaProvider.Save(transactionManager, entity.Macchina);
					deepHandles.Add("Macchina",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< Macchina >) DataRepository.MacchinaProvider.DeepSave,
						new object[] { transactionManager, entity.Macchina, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 
	
			#region List<Motore>
				if (CanDeepSave(entity.MotoreCollection, "List<Motore>|MotoreCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Motore child in entity.MotoreCollection)
					{
						if(child.AggregationMotoreIDSource != null)
						{
							child.AggregationMotoreID = child.AggregationMotoreIDSource.ID;
						}
						else
						{
							child.AggregationMotoreID = entity.ID;
						}

					}

					if (entity.MotoreCollection.Count > 0 || entity.MotoreCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MotoreProvider.Save(transactionManager, entity.MotoreCollection);
						
						deepHandles.Add("MotoreCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Motore >) DataRepository.MotoreProvider.DeepSave,
							new object[] { transactionManager, entity.MotoreCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Pistone>
				if (CanDeepSave(entity.PistoneCollection, "List<Pistone>|PistoneCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Pistone child in entity.PistoneCollection)
					{
						if(child.CompositionMotoreIDSource != null)
						{
							child.CompositionMotoreID = child.CompositionMotoreIDSource.ID;
						}
						else
						{
							child.CompositionMotoreID = entity.ID;
						}

					}

					if (entity.PistoneCollection.Count > 0 || entity.PistoneCollection.DeletedItems.Count > 0)
					{
						//DataRepository.PistoneProvider.Save(transactionManager, entity.PistoneCollection);
						
						deepHandles.Add("PistoneCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Pistone >) DataRepository.PistoneProvider.DeepSave,
							new object[] { transactionManager, entity.PistoneCollection, deepSaveType, childTypes, innerList }
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
	
	#region MotoreChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>GenTest.Entities.Motore</c>
	///</summary>
	public enum MotoreChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Motore</c> at AggregationMotoreIDSource
		///</summary>
		[ChildEntityType(typeof(Motore))]
		Motore,
	
		///<summary>
		/// Collection of <c>Motore</c> as OneToMany for MotoreCollection
		///</summary>
		[ChildEntityType(typeof(TList<Motore>))]
		MotoreCollection,

		///<summary>
		/// Collection of <c>Motore</c> as OneToMany for PistoneCollection
		///</summary>
		[ChildEntityType(typeof(TList<Pistone>))]
		PistoneCollection,
		///<summary>
		/// Entity <c>Macchina</c> as OneToOne for Macchina
		///</summary>
		[ChildEntityType(typeof(Macchina))]
		Macchina,
	}
	
	#endregion MotoreChildEntityTypes
	
	#region MotoreFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MotoreColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Motore"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MotoreFilterBuilder : SqlFilterBuilder<MotoreColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MotoreFilterBuilder class.
		/// </summary>
		public MotoreFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MotoreFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MotoreFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MotoreFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MotoreFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MotoreFilterBuilder
	
	#region MotoreParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MotoreColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Motore"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MotoreParameterBuilder : ParameterizedSqlFilterBuilder<MotoreColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MotoreParameterBuilder class.
		/// </summary>
		public MotoreParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MotoreParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MotoreParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MotoreParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MotoreParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MotoreParameterBuilder
} // end namespace
