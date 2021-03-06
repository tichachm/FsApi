﻿using System;

namespace FsApi
{
  public abstract class FsResult
  {
    public string Command { get; internal set; }

    public Exception Error { get; set; }

    public bool Succeeded { get { return Error == null && !IsTimeOut; } }

    public bool IsTimeOut { get; private set; }

    public override string ToString()
    {
      return "Succeeded: " + Succeeded;
    }
  }

  public class FsResult<T> : FsResult
  {
        public FsResult()
        {
        }

        internal FsResult(T value = default(T))
    {
      Value = value;
    }

    public T Value { get; private set; }

    public override string ToString()
    {
      return base.ToString() + "; Value:" + Value.ToString();
    }
  }
}