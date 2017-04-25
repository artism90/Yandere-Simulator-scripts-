using System;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;

namespace CompilerGenerated
{
	// Token: 0x02000197 RID: 407
	[CompilerGenerated]
	[Serializable]
	public sealed class __MusicTest$callable0$51_28__ : MulticastDelegate, ICallable
	{
		// Token: 0x06000848 RID: 2120
		public extern __MusicTest$callable0$51_28__(object instance, IntPtr method);

		// Token: 0x06000849 RID: 2121 RVA: 0x000BD0A4 File Offset: 0x000BB2A4
		[DuckTyped]
		public object Call(object[] args)
		{
			return this(RuntimeServices.UnboxSingle(args[0]));
		}

		// Token: 0x0600084A RID: 2122
		public extern float Invoke(float f);

		// Token: 0x0600084B RID: 2123
		public extern IAsyncResult BeginInvoke(float f, AsyncCallback callback, object asyncState);

		// Token: 0x0600084C RID: 2124
		public extern float EndInvoke(IAsyncResult result);
	}
}
