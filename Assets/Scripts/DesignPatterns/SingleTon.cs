using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//========================================
//##		������ ���� SingleTon		##
//========================================
/*
	�̱��� ���� :
	���� �� ���� Ŭ���� �ν��Ͻ����� ������ ����
	�̿� ���� �������� �������� ����

	���� :
	1. �������� ���� ������ �ν��Ͻ��� �ּҸ� ���� ����
	������ ���� �޸� ������ Ȱ�� (��������)
	2. ���������� Ȱ���Ͽ� ĸ��ȭ�� ����
	3. �������� ���ٱ����� �ܺο��� ������ �� ������ ����
	4. Instance �Ӽ��� ���� �ν��Ͻ��� ������ �� �ֵ��� ��
	5. instance ������ �� �ϳ��� �ֵ��� ����

	���� :
	1. �ϳ����� ����� �ֿ� Ŭ����, �������� ������ ��
	2. ������ �������� ������ �ʿ��� �۾��� ���� �������ٰ���
	3. �ν��Ͻ����� �̱����� ���Ͽ� �����͸� �����ϱ� ������

	���� :
	1. �̱����� �ʹ� ���� å���� �������� ��츦 �����ؾ���
	2. �̱����� ���߷� ���������� �������� �Ǵ� ���, ������ �ڵ� ���յ��� ������
	3. �̱����� �����͸� ������ ��� ������ ������ �����ؾ���
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
		inventory1 = Inventory.GetInstance();       // ó�� �ҷ��ö��� �ν��Ͻ��� �����ؼ� �־���
		inventory2 = Inventory.GetInstance();       // ���� �ٽ� �ҷ��ô�� ������ �ν��Ͻ��� �״�� �Ѱ���
	}

	public void Test()
	{
		SingleTon singleTon1 = SingleTon.Instance;	// ó�� ������ ������ �ҷ����� �ν��Ͻ��� ��� ���� �ν��Ͻ� ��, ���� ��ü�̴�.
        SingleTon singleTon2 = SingleTon.Instance;
        SingleTon singleTon3 = SingleTon.Instance;
        SingleTon singleTon4 = SingleTon.Instance;

		// SingleTon singleTon5 = new SingleTon();	// �����ڰ� private�̹Ƿ� ��ü������ �ν��Ͻ��� ������ �� ����
    }
}
