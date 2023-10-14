// THIS FILE IS AUTOMATICALLY GENERATED BY SPACETIMEDB. EDITS TO THIS FILE
// WILL NOT BE SAVED. MODIFY TABLES IN RUST INSTEAD.

using System;
using System.Collections.Generic;
using SpacetimeDB;

namespace SpacetimeDB.Types
{
	public partial class EntityComponent : IDatabaseTable
	{
		[Newtonsoft.Json.JsonProperty("entity_id")]
		public ulong EntityId;
		[Newtonsoft.Json.JsonProperty("position")]
		public SpacetimeDB.Types.StdbVector3 Position;
		[Newtonsoft.Json.JsonProperty("direction")]
		public float Direction;
		[Newtonsoft.Json.JsonProperty("moving")]
		public bool Moving;

		private static Dictionary<ulong, EntityComponent> EntityId_Index = new Dictionary<ulong, EntityComponent>(16);

		private static void InternalOnValueInserted(object insertedValue)
		{
			var val = (EntityComponent)insertedValue;
			EntityId_Index[val.EntityId] = val;
		}

		private static void InternalOnValueDeleted(object deletedValue)
		{
			var val = (EntityComponent)deletedValue;
			EntityId_Index.Remove(val.EntityId);
		}

		public static SpacetimeDB.SATS.AlgebraicType GetAlgebraicType()
		{
			return SpacetimeDB.SATS.AlgebraicType.CreateProductType(new SpacetimeDB.SATS.ProductTypeElement[]
			{
				new SpacetimeDB.SATS.ProductTypeElement("entity_id", SpacetimeDB.SATS.AlgebraicType.CreatePrimitiveType(SpacetimeDB.SATS.BuiltinType.Type.U64)),
				new SpacetimeDB.SATS.ProductTypeElement("position", SpacetimeDB.Types.StdbVector3.GetAlgebraicType()),
				new SpacetimeDB.SATS.ProductTypeElement("direction", SpacetimeDB.SATS.AlgebraicType.CreatePrimitiveType(SpacetimeDB.SATS.BuiltinType.Type.F32)),
				new SpacetimeDB.SATS.ProductTypeElement("moving", SpacetimeDB.SATS.AlgebraicType.CreatePrimitiveType(SpacetimeDB.SATS.BuiltinType.Type.Bool)),
			});
		}

		public static explicit operator EntityComponent(SpacetimeDB.SATS.AlgebraicValue value)
		{
			if (value == null) {
				return null;
			}
			var productValue = value.AsProductValue();
			return new EntityComponent
			{
				EntityId = productValue.elements[0].AsU64(),
				Position = (SpacetimeDB.Types.StdbVector3)(productValue.elements[1]),
				Direction = productValue.elements[2].AsF32(),
				Moving = productValue.elements[3].AsBool(),
			};
		}

		public static System.Collections.Generic.IEnumerable<EntityComponent> Iter()
		{
			foreach(var entry in SpacetimeDBClient.clientDB.GetEntries("EntityComponent"))
			{
				yield return (EntityComponent)entry.Item2;
			}
		}
		public static int Count()
		{
			return SpacetimeDBClient.clientDB.Count("EntityComponent");
		}
		public static EntityComponent FilterByEntityId(ulong value)
		{
			EntityId_Index.TryGetValue(value, out var r);
			return r;
		}

		public static System.Collections.Generic.IEnumerable<EntityComponent> FilterByDirection(float value)
		{
			foreach(var entry in SpacetimeDBClient.clientDB.GetEntries("EntityComponent"))
			{
				var productValue = entry.Item1.AsProductValue();
				var compareValue = (float)productValue.elements[2].AsF32();
				if (compareValue == value) {
					yield return (EntityComponent)entry.Item2;
				}
			}
		}

		public static System.Collections.Generic.IEnumerable<EntityComponent> FilterByMoving(bool value)
		{
			foreach(var entry in SpacetimeDBClient.clientDB.GetEntries("EntityComponent"))
			{
				var productValue = entry.Item1.AsProductValue();
				var compareValue = (bool)productValue.elements[3].AsBool();
				if (compareValue == value) {
					yield return (EntityComponent)entry.Item2;
				}
			}
		}

		public static bool ComparePrimaryKey(SpacetimeDB.SATS.AlgebraicType t, SpacetimeDB.SATS.AlgebraicValue v1, SpacetimeDB.SATS.AlgebraicValue v2)
		{
			var primaryColumnValue1 = v1.AsProductValue().elements[0];
			var primaryColumnValue2 = v2.AsProductValue().elements[0];
			return SpacetimeDB.SATS.AlgebraicValue.Compare(t.product.elements[0].algebraicType, primaryColumnValue1, primaryColumnValue2);
		}

		public static SpacetimeDB.SATS.AlgebraicValue GetPrimaryKeyValue(SpacetimeDB.SATS.AlgebraicValue v)
		{
			return v.AsProductValue().elements[0];
		}

		public static SpacetimeDB.SATS.AlgebraicType GetPrimaryKeyType(SpacetimeDB.SATS.AlgebraicType t)
		{
			return t.product.elements[0].algebraicType;
		}

		public delegate void InsertEventHandler(EntityComponent insertedValue, SpacetimeDB.Types.ReducerEvent dbEvent);
		public delegate void UpdateEventHandler(EntityComponent oldValue, EntityComponent newValue, SpacetimeDB.Types.ReducerEvent dbEvent);
		public delegate void DeleteEventHandler(EntityComponent deletedValue, SpacetimeDB.Types.ReducerEvent dbEvent);
		public delegate void RowUpdateEventHandler(SpacetimeDBClient.TableOp op, EntityComponent oldValue, EntityComponent newValue, SpacetimeDB.Types.ReducerEvent dbEvent);
		public static event InsertEventHandler OnInsert;
		public static event UpdateEventHandler OnUpdate;
		public static event DeleteEventHandler OnBeforeDelete;
		public static event DeleteEventHandler OnDelete;
		public static event RowUpdateEventHandler OnRowUpdate;

		public static void OnInsertEvent(object newValue, ClientApi.Event dbEvent)
		{
			OnInsert?.Invoke((EntityComponent)newValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}

		public static void OnUpdateEvent(object oldValue, object newValue, ClientApi.Event dbEvent)
		{
			OnUpdate?.Invoke((EntityComponent)oldValue,(EntityComponent)newValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}

		public static void OnBeforeDeleteEvent(object oldValue, ClientApi.Event dbEvent)
		{
			OnBeforeDelete?.Invoke((EntityComponent)oldValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}

		public static void OnDeleteEvent(object oldValue, ClientApi.Event dbEvent)
		{
			OnDelete?.Invoke((EntityComponent)oldValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}

		public static void OnRowUpdateEvent(SpacetimeDBClient.TableOp op, object oldValue, object newValue, ClientApi.Event dbEvent)
		{
			OnRowUpdate?.Invoke(op, (EntityComponent)oldValue,(EntityComponent)newValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}
	}
}