﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using GenTest.Entities;
using GenTest.Data;

#endregion

namespace GenTest.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="MotoreProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MotoreProviderBase : MotoreProviderBaseCore
	{
	} // end class
} // end namespace
