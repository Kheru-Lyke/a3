using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
	public class ConnectionAnchor : InteractionAnchor {
		private List<IConnector> linkedConnections = new List<IConnector>();
		private bool isConnected = false;

		protected override void InitializeList() {
			IConnector connector = null;

			foreach (GameObject connection in linkedObjects) {
				connector = connection.GetComponentInChildren<IConnector>();
				if (connector != null) linkedConnections.Add(connector);
			}
		}

		protected override void ActOnLinked() {

			foreach (IConnector connector in linkedConnections) {
				if (isConnected) connector.Disconnect();
				else
					connector.Connect(player);

			}

			isConnected = !isConnected;
			player.SetMoving(!isConnected);

		}
	}
}
