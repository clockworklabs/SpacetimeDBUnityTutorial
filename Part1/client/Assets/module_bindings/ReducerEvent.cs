// THIS FILE IS AUTOMATICALLY GENERATED BY SPACETIMEDB. EDITS TO THIS FILE
// WILL NOT BE SAVED. MODIFY TABLES IN RUST INSTEAD.

using System;
using ClientApi;
using Newtonsoft.Json.Linq;
using SpacetimeDB;

namespace SpacetimeDB.Types
{
	public enum ReducerType
	{
		None,
		CreatePlayer,
		SendChatMessage,
		UpdatePlayerPosition,
	}

	public partial class ReducerEvent : ReducerEventBase
	{
		public ReducerType Reducer { get; private set; }

		public ReducerEvent(ReducerType reducer, string reducerName, ulong timestamp, SpacetimeDB.Identity identity, SpacetimeDB.Address? callerAddress, string errMessage, ClientApi.Event.Types.Status status, object args)
			: base(reducerName, timestamp, identity, callerAddress, errMessage, status, args)
		{
			Reducer = reducer;
		}

		public CreatePlayerArgsStruct CreatePlayerArgs
		{
			get
			{
				if (Reducer != ReducerType.CreatePlayer) throw new SpacetimeDB.ReducerMismatchException(Reducer.ToString(), "CreatePlayer");
				return (CreatePlayerArgsStruct)Args;
			}
		}
		public SendChatMessageArgsStruct SendChatMessageArgs
		{
			get
			{
				if (Reducer != ReducerType.SendChatMessage) throw new SpacetimeDB.ReducerMismatchException(Reducer.ToString(), "SendChatMessage");
				return (SendChatMessageArgsStruct)Args;
			}
		}
		public UpdatePlayerPositionArgsStruct UpdatePlayerPositionArgs
		{
			get
			{
				if (Reducer != ReducerType.UpdatePlayerPosition) throw new SpacetimeDB.ReducerMismatchException(Reducer.ToString(), "UpdatePlayerPosition");
				return (UpdatePlayerPositionArgsStruct)Args;
			}
		}

		public object[] GetArgsAsObjectArray()
		{
			switch (Reducer)
			{
				case ReducerType.CreatePlayer:
				{
					var args = CreatePlayerArgs;
					return new object[] {
						args.Username,
					};
				}
				case ReducerType.SendChatMessage:
				{
					var args = SendChatMessageArgs;
					return new object[] {
						args.Text,
					};
				}
				case ReducerType.UpdatePlayerPosition:
				{
					var args = UpdatePlayerPositionArgs;
					return new object[] {
						args.Position,
						args.Direction,
						args.Moving,
					};
				}
				default: throw new System.Exception($"Unhandled reducer case: {Reducer}. Please run SpacetimeDB code generator");
			}
		}
	}
}
