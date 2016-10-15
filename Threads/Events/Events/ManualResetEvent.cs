using System;

namespace Events.Events {
    public class ManualResetEvent {


        public delegate void StatusUpdateHandler(object sender, ManualResetEventArgs e);
        public event StatusUpdateHandler OnFileReady;

        public void SetReady(bool ready) {
            FileSetReady(ready);
        }


        private void FileSetReady(bool isFileReady) {
            var args = new ManualResetEventArgs(isFileReady);
            OnFileReady?.Invoke(this, args);
        }
    }

    public class ManualResetEventArgs : EventArgs {
        public bool IsFileReady { get; set; }

        public ManualResetEventArgs(bool isFileReady) {
            IsFileReady = isFileReady;
        }
    }
}
