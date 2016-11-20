(ns solution.payment)

(defn product-has-type?
  [product type]
  (let [types (:types product)]
    (some #{type} types)))

(defn build-payment-rule
  [activation-check activator]
  {:activation-check (fn [product] (activation-check product))
   :activator        (fn [product] (activator product))})

(defn generate-packing-slip-stub
  "Stub function for packaging slip generation/save/send."
  [product](println (str "Packaging slip for: " product)))

(defn generate-duplicate-packaging-slip-stub
  "Stub function for duplicate packaging slip generation/save/send."
  [product](println (str "Duplicate packaging slip for: " product)))

(def payment-rules
  (list (build-payment-rule #(product-has-type? % :physical)
                            #(generate-packing-slip-stub %))
        (build-payment-rule #(product-has-type? % :book)
                            #(generate-duplicate-packaging-slip-stub %))))

(defn execute-rule-if-applies
  [product rule]
  (let [rule-applies? (:activation-check rule)
        execute-rule (:activator rule)]
    (when (rule-applies? product)
      (execute-rule product))))

(defn recieve-payment
  "Handles new payment"
  ([payment]
    (recieve-payment payment payment-rules))
  ([payment rules]
    (let [product (:product payment)]
      (doall (map #(execute-rule-if-applies product %) rules)))))