using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface FigureFactory_interface {
	MeatBall CreateMeatBall<T> (Vector3 _spawnPosition,int _id,int _force) where T : MeatBall, new() ;
	//Moster CreateMoster<T> (Vector3 _spawnPosition,int _id,int _force) where T : Figure, new() ;
}

public class FigureFactory : FigureFactory_interface{

	private FigureBuilderSystem myBuildDirector = new FigureBuilderSystem ();

	public MeatBall CreateMeatBall<T> (Vector3 spawnPosition,int _id,int _force) where T : MeatBall, new() {
		MeatBall meatball = new T ();

		if (meatball == null)
			return null;

		MeatBallPara MBPara = new MeatBallPara ();
		MBPara.spawnPosition = spawnPosition;
		MBPara.AttrID = _id;
		MBPara.forces = _force;

		MeatBallBuilder MBBuilder = new MeatBallBuilder ();
		MBBuilder.SetBuildPara (MBPara);

		myBuildDirector.Build (MBBuilder);

		return meatball;
	}
	/*
	public Moster CreateMeatBall<T> (Vector3 spawnPosition,int _id,int _force) where T : Moster, new() {
		Moster moster = new T ();

		if (moster == null)
			return null;

		Moster MBPara = new MeatBallPara ();
		MBPara.spawnPosition = spawnPosition;
		MBPara.AttrID = _id;
		MBPara.forces = _force;

		MeatBallBuilder MBBuilder = new MeatBallBuilder (ref myBuildDirector);
		MBBuilder.SetBuildPara (MBPara);

		myBuildDirector.Build (MBBuilder);
	}*/
}
