using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//========================================
//##		디자인 패턴 SingleTon		##
//========================================
/*
	싱글톤 패턴 :
	오직 한 개의 클래스 인스턴스만을 갖도록 보장
	이에 대한 전역적인 접근점을 제공

	구현 :
	1. 전역에서 접근 가능한 인스턴스의 주소를 갖기 위해
	데이터 영역 메모리 공간을 활용 (정적변수)
	2. 정적변수를 활용하여 캡슐화를 진행
	3. 생성자의 접근권한을 외부에서 생성할 수 없도록 제한
	4. Instance 속성를 통해 인스턴스에 접근할 수 있도록 함
	5. instance 변수는 단 하나만 있도록 유지

	장점 :
	1. 하나뿐인 존재로 주요 클래스, 관리자의 역할을 함
	2. 전역적 접근으로 참조에 필요한 작업이 없이 빠른접근가능
	3. 인스턴스들이 싱글톤을 통하여 데이터를 공유하기 쉬워짐

	단점 :
	1. 싱글톤이 너무 많은 책임을 짊어지는 경우를 주의해야함
	2. 싱글톤의 남발로 전역접근이 많아지게 되는 경우, 참조한 코드 결합도가 높아짐
	3. 싱글톤의 데이터를 공유할 경우 데이터 변조에 주의해야함
*/

public class SingleTon
{
    private static SingleTon instance;

    public static SingleTon Instance
    {
        get
        {
            if (instance == null)
                instance = new SingleTon();

            return instance;
        }
    }

    private SingleTon() { }
}

public class Inventory
{
	private static Inventory instance;

	private Inventory() { }

	public static Inventory GetInstance()
	{
		if (instance != null)
			return instance;

		instance = new Inventory();
		return instance;
	}
}

public class Player
{
	Inventory inventory1;
	Inventory inventory2;

	public Player()
	{
		inventory1 = Inventory.GetInstance();       // 처음 불러올때는 인스턴스를 생성해서 넣어줌
		inventory2 = Inventory.GetInstance();       // 다음 다시 불러올대는 기존의 인스턴스를 그대로 넘겨줌
	}

	public void Test()
	{
		SingleTon singleTon1 = SingleTon.Instance;	// 처음 생성한 다음에 불러오는 인스턴스는 모두 기존 인스턴스 즉, 같은 객체이다.
        SingleTon singleTon2 = SingleTon.Instance;
        SingleTon singleTon3 = SingleTon.Instance;
        SingleTon singleTon4 = SingleTon.Instance;

		// SingleTon singleTon5 = new SingleTon();	// 생성자가 private이므로 자체적으로 인스턴스를 생성할 수 없음
    }
}
