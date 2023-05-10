﻿/*
 * SuperSwaunch - The incremental-search task switcher for Windows.
 * http://www.SuperSwaunch.io/
 * Copyright 2009, 2010 James Sulak
 * Copyright 2014 Regin Larsen
 * 
 * SuperSwaunch is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SuperSwaunch is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with SuperSwaunch.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System.Linq;

namespace SuperSwaunch.Core
{
    public class WindowFinder
    {
        public List<AppWindow> GetWindows()
        {
            var allToplevelWindows = AppWindow.AllToplevelWindows;
            var reminder = allToplevelWindows.Where(x => x.Title.Contains("Reminder")).ToList();
            return allToplevelWindows
                .Where(a => a.IsAltTabWindow())
                .ToList();
        }
    }
}