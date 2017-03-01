using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FigurePara{
	public Vector3 spawnPosition;
	public Figure myFigure = null;
	public string assetName;
	public string iconName;
	public int forces;
	public int AttrID;
}

public abstract class FigureBuilder {
	public abstract void SetBuildPara (FigurePara _para);
	public abstract void LoadUnityAsset(int _id);
	public abstract void AddUnityEvent();
	public abstract void SetFigureValue();
	public abstract void AddFigureInSystem(WOMMGame _game);
	public abstract void AddAI();
}

public class MeatBallPara : FigurePara{
	public MeatBallSuit mySuit;
}

public class MeatBallBuilder : FigureBuilder{ 

	private MeatBallPara myMeatBallPara;

	public override void SetBuildPara (FigurePara _par)
	{
		myMeatBallPara = _par as MeatBallPara;
	}

	public override void LoadUnityAsset (int _id)
	{
		
	}

	public override void AddUnityEvent ()
	{
		
	}

	public override void SetFigureValue ()
	{
		
	}

	public override void AddFigureInSystem (WOMMGame _game)
	{
		
	}

	public override void AddAI ()
	{
		
	}
}

