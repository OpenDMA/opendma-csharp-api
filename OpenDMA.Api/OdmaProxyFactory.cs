using Castle.DynamicProxy;
using System;
using System.Collections.Generic;

namespace OpenDMA.Api
{
    public static class OdmaProxyFactory
    {
        private static readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();
        private static readonly Dictionary<OdmaQName, Type> INTERFACE_DICT = new Dictionary<OdmaQName, Type>();

        static OdmaProxyFactory()
        {
            INTERFACE_DICT[OdmaCommonNames.CLASS_CLASS] = typeof(IOdmaClass);
            INTERFACE_DICT[OdmaCommonNames.CLASS_PROPERTYINFO] = typeof(IOdmaPropertyInfo);
            INTERFACE_DICT[OdmaCommonNames.CLASS_CHOICEVALUE] = typeof(IOdmaChoiceValue);
            INTERFACE_DICT[OdmaCommonNames.CLASS_REPOSITORY] = typeof(IOdmaRepository);
            INTERFACE_DICT[OdmaCommonNames.CLASS_DOCUMENT] = typeof(IOdmaDocument);
            INTERFACE_DICT[OdmaCommonNames.CLASS_CONTENTELEMENT] = typeof(IOdmaContentElement);
            INTERFACE_DICT[OdmaCommonNames.CLASS_DATACONTENTELEMENT] = typeof(IOdmaDataContentElement);
            INTERFACE_DICT[OdmaCommonNames.CLASS_REFERENCECONTENTELEMENT] = typeof(IOdmaReferenceContentElement);
            INTERFACE_DICT[OdmaCommonNames.CLASS_VERSIONCOLLECTION] = typeof(IOdmaVersionCollection);
            INTERFACE_DICT[OdmaCommonNames.CLASS_CONTAINER] = typeof(IOdmaContainer);
            INTERFACE_DICT[OdmaCommonNames.CLASS_FOLDER] = typeof(IOdmaFolder);
            INTERFACE_DICT[OdmaCommonNames.CLASS_CONTAINABLE] = typeof(IOdmaContainable);
            INTERFACE_DICT[OdmaCommonNames.CLASS_ASSOCIATION] = typeof(IOdmaAssociation);
        }

        public static IOdmaObject CreateProxy(IOdmaCoreObject coreObject, List<OdmaQName> classNames)
        {
            var interfaces = new List<Type>();

            foreach (var className in classNames)
            {
                if (INTERFACE_DICT.TryGetValue(className, out Type? iface))
                {
                    interfaces.Add(iface);
                }
            }

            // Create the proxy with all mapped interfaces
            var proxy = _proxyGenerator.CreateInterfaceProxyWithoutTarget(
                typeof(IOdmaObject),
                interfaces.ToArray(),
                new OdmaProxyInterceptor(coreObject)
            );

            return (IOdmaObject)proxy;
        }
    }
}
