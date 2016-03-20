﻿using System;
using System.ComponentModel;

namespace GenTest.Entities
{
	/// <summary>
	///		The data structure representation of the 'Specchietto' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ISpecchietto 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Specchietto"</remarks>
		System.Int32 ID { get; set; }
				
		
		
		/// <summary>
		/// Larghezza : 
		/// </summary>
		System.Double  Larghezza  { get; set; }
		
		/// <summary>
		/// AggregationMacchinaID : 
		/// </summary>
		System.Int32?  AggregationMacchinaID  { get; set; }
		
		/// <summary>
		/// SgutAssociationSpecchiettoID : 
		/// </summary>
		System.Int32?  SgutAssociationSpecchiettoID  { get; set; }
		
		/// <summary>
		/// AssociationSpecchiettoID : 
		/// </summary>
		System.Int32?  AssociationSpecchiettoID  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties
	

		/// <summary>
		///	Holds a  Specchietto entity object
		///	which is related to this object through the relation _specchiettoAssociationSpecchiettoIDGetBySgutAssociationSpecchiettoID
		/// </summary>
		Specchietto SpecchiettoGetBySgutAssociationSpecchiettoID { get; set; }
	

		/// <summary>
		///	Holds a  Specchietto entity object
		///	which is related to this object through the relation _specchiettoAssociationSpecchiettoIDGetByAssociationSpecchiettoID
		/// </summary>
		Specchietto SpecchiettoGetByAssociationSpecchiettoID { get; set; }

		#endregion Data Properties

	}
}

