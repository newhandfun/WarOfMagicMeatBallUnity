using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConnectionMethod {
    Null,
    Photon,
    Unet
}

public class Connection{
    static ConnectionMethod connectionMethod = ConnectionMethod.Photon;
    public static ConnectionMethod GetConnectionMethod {
        get { return connectionMethod; }
    }
}
