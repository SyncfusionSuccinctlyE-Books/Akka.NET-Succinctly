using Akka.Actor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Chapter11.test
{
    //Explain the difference between the Tell and Forward.
    //Unit testing here works only if the coordinator actor uses Forwarding
    //
    public class ChildActor : ReceiveActor
    {
        public ChildActor()
        {
            ReceiveAny(o => Sender.Tell("hello!"));
        }
    }

    public class ParentActor : ReceiveActor
    {
        public ParentActor()
        {
            var child = Context.ActorOf(Props.Create(() => new ChildActor()));
            ReceiveAny(o => child.Forward(o));
        }
    }

    [TestFixture]
    public class ParentGreeterSpecs : Akka.TestKit.NUnit.TestKit
    {
        [Test]
        public void Parent_should_create_child_original()
        {
            // verify child has been created by sending parent a message
            // that is forwarded to child, and which child replies to sender with
            var parentProps = Props.Create(() => new ParentActor());
            var parent = ActorOfAsTestActorRef<ParentActor>(parentProps, TestActor);
            parent.Tell("this should be forwarded to the child");
            ExpectMsg("hello!");
        }
    }
}
