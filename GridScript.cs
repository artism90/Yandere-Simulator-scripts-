using System;
using UnityEngine;

// Token: 0x020000A4 RID: 164
[Serializable]
public class GridScript : MonoBehaviour
{
	// Token: 0x060003A8 RID: 936 RVA: 0x00049AD0 File Offset: 0x00047CD0
	public GridScript()
	{
		this.Rows = 25;
		this.Columns = 25;
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00049AE8 File Offset: 0x00047CE8
	public virtual void Start()
	{
		while (this.ID < this.Rows * this.Columns)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Tile, new Vector3((float)this.Row, (float)0, (float)this.Column), Quaternion.identity);
			gameObject.transform.parent = this.transform;
			this.Row++;
			if (this.Row > this.Rows)
			{
				this.Row = 1;
				this.Column++;
			}
			this.ID++;
		}
		this.transform.localScale = new Vector3((float)4, (float)4, (float)4);
		this.transform.position = new Vector3((float)-52, (float)0, (float)-52);
	}

	// Token: 0x060003AA RID: 938 RVA: 0x00049BC0 File Offset: 0x00047DC0
	public virtual void Main()
	{
	}

	// Token: 0x04000911 RID: 2321
	public GameObject Tile;

	// Token: 0x04000912 RID: 2322
	public int Row;

	// Token: 0x04000913 RID: 2323
	public int Column;

	// Token: 0x04000914 RID: 2324
	public int Rows;

	// Token: 0x04000915 RID: 2325
	public int Columns;

	// Token: 0x04000916 RID: 2326
	public int ID;
}
