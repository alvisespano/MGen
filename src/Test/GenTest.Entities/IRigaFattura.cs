﻿using System;
using System.ComponentModel;

namespace GenTest.Entities
{
	/// <summary>
	///		The data structure representation of the 'RigaFattura' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IRigaFattura 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "RigaFattura"</remarks>
		System.Int32 ID { get; set; }
				
		
		
		/// <summary>
		/// Descrizione : 
		/// </summary>
		System.String  Descrizione  { get; set; }
		
		/// <summary>
		/// Importo : 
		/// </summary>
		System.Double  Importo  { get; set; }
		
		/// <summary>
		/// ComposedFatturaID : 
		/// </summary>
		System.Int32?  ComposedFatturaID  { get; set; }
		
		/// <summary>
		/// AggregatedFatturaID : 
		/// </summary>
		System.Int32?  AggregatedFatturaID  { get; set; }
		
		/// <summary>
		/// AssociatedFatturaID : 
		/// </summary>
		System.Int32?  AssociatedFatturaID  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation fatturaAggregatedRigaFatturaIDGetByAggregatedRigaFatturaID
		/// </summary>	
		TList<Fattura> FatturaCollectionGetByAggregatedRigaFatturaID {  get;  set;}	
	

		/// <summary>
		///	Holds a  Fattura entity object
		///	which is related to this object through the relation fatturaAssociatedRigaFatturaID
		/// </summary>
		Fattura Fattura { get; set; }


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation fatturaAggregatedRigaFatturaIDGetByComposedRigaFatturaID
		/// </summary>	
		TList<Fattura> FatturaCollectionGetByComposedRigaFatturaID {  get;  set;}	

		#endregion Data Properties

	}
}

