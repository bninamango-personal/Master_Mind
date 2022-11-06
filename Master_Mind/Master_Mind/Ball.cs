using System;
using System.Collections.Generic;
using System.Text;

namespace bninamango
{
    class Ball
    {
        private char character;
        private int index;

        public char Character
        {
            get => character;
        }

        public int Index
        {
            get => index;
        }

        public Ball(char character, int index)
        {
            this.character = character;
            this.index = index;
        }
    }
}