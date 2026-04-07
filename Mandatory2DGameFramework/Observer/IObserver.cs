using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Observer
{
    /// <summary>
    /// Observer interface for receiving notifications from subjects.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Updates the observer with a message from the subject.
        /// </summary>
        /// <param name="subject">The subject sending the update.</param>
        /// <param name="message">The message describing the update.</param>
        void Update(ISubject subject, string message);
    }
}
