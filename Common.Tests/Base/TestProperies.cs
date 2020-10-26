using Common.Tests.WebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.Base {
    public class TestProperies {
        readonly bool checkExistsElement;
        public TestProperies(bool checkExistsElement) {
            this.checkExistsElement = checkExistsElement;
        }
        internal void testElements() {
            List<PropertyInfo> properties = GetType().GetProperties()
                .Where(p => p.GetCustomAttributes().All(a => a.GetType() != typeof(SkipElementAttribute))).ToList();
            if (checkExistsElement) {
                properties.All(p => {
                    bool result = Executor.SpinWait(() => {
                        if (testType(p.PropertyType)) {
                            if (p.PropertyType.IsGenericType) {
                                return ((IEnumerable<WebElement>)p.GetValue(this)).ToList()
                                    .All(pe => {
                                        if (!Executor.SpinWait(() => pe.Exist)) {
                                            throw new Exception($"Property {p.Name} ellement in coolection no exist.");
                                        }
                                        return true;
                                    });
                            } else {
                                if (!Executor.SpinWait(() => (p.GetValue(this) as WebElement).Exist)) {
                                    throw new Exception($"Property {p.Name} no exist.");
                                }
                                return true;
                            }
                        } else {
                            throw new Exception($"Type {GetType().Name} properties must be WebElement or List<WebElement>, however property {p.Name} is {p.PropertyType}");
                        }
                    });
                    return result;
                });
            }
        }
        bool testType(Type type) {
            if (type.IsGenericType) {
                return (type.GetGenericTypeDefinition().Equals(typeof(List<>))
                    || type.GetGenericTypeDefinition().IsSubclassOf(typeof(List<>)))
                    && (type.GetGenericArguments()[0].Equals(typeof(WebElement))
                    || type.GetGenericArguments()[0].IsSubclassOf(typeof(WebElement)));
            } else {
                return type.Equals(typeof(WebElement)) || type.IsSubclassOf(typeof(WebElement));
            }
        }
    }
}
