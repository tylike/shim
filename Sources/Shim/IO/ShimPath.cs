﻿/*
 *  Copyright (c) 2013-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of Shim.
 *
 *  Shim is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  Shim is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with Shim. If not, see <http://www.gnu.org/licenses/>.
 */

#if NETFX_CORE
using Windows.Storage;
#endif

namespace System.IO
{
    /// <summary>
    /// Shim complement for the <see cref="Path"/> class, providing members that are
    /// not included in the PCL member subset of the <see cref="Path"/> class.
    /// </summary>
    public static class ShimPath
    {
        #region FIELDS

        /// <include file='../_Doc/mscorlib.xml' path='doc/members/member[@name="F:System.IO.Path.PathSeparator"]/*' />
        public static readonly char PathSeparator = '\\';

        /// <include file='../_Doc/mscorlib.xml' path='doc/members/member[@name="F:System.IO.Path.DirectorySeparatorChar"]/*' />
        public static readonly char DirectorySeparatorChar = '\\';

        #endregion

        #region METHODS

        /// <include file='../_Doc/mscorlib.xml' path='doc/members/member[@name="M:System.IO.Path.GetTempPath"]/*' />
        public static string GetTempPath()
        {
#if NETFX_CORE
            return ApplicationData.Current.TemporaryFolder.Path;
#elif SILVERLIGHT || DOTNET
            return Path.GetTempPath();
#else
            throw new PlatformNotSupportedException("PCL");
#endif
        }

        /// <include file='../_Doc/mscorlib.xml' path='doc/members/member[@name="M:System.IO.Path.GetTempFileName"]/*' />
        public static string GetTempFileName()
        {
#if NETFX_CORE
            const string DefaultFileExtension = ".tmp";
            return Path.ChangeExtension(global::System.IO.Path.Combine(GetTempPath(),
                                                  global::System.IO.Path.GetRandomFileName()), DefaultFileExtension);
#elif SILVERLIGHT || DOTNET
            return Path.GetTempFileName();
#else
            throw new PlatformNotSupportedException("PCL");
#endif
        }

        /// <include file='../_Doc/mscorlib.xml' path='doc/members/member[@name="M:System.IO.Path.GetFullPath(System.String)"]/*' />
        public static string GetFullPath(string path)
        {
#if NETFX_CORE
            return path;
#elif SILVERLIGHT || DOTNET
            return Path.GetFullPath(path);
#else
            throw new PlatformNotSupportedException("PCL");
#endif
        }

        /// <include file='../_Doc/mscorlib.xml' path='doc/members/member[@name="M:System.IO.Path.GetDirectoryName(System.String)"]/*' />
        public static string GetDirectoryName(string path)
        {
#if PROFILE328
            throw new PlatformNotSupportedException("PCL");
#else
            return Path.GetDirectoryName(path);
#endif
        }

        /// <include file='../_Doc/mscorlib.xml' path='doc/members/member[@name="M:System.IO.Path.Combine(System.String[])"]/*' />
        public static string Combine(params string[] paths)
        {
#if PROFILE328
            throw new PlatformNotSupportedException("PCL");
#else
            return Path.Combine(paths);
#endif
        }

        #endregion
    }
}